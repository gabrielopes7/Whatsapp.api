
using System.Text;
using System.Text.Json;
using RestSharp;
using Whatsapp.Microservice.Models.Requisicao;
using Whatsapp.Microservice.Models.Resposta;
using Whatsapp.Microservice.Models.Telefone;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Service
{
    public class MetaApiService : IMetaApiService
    {
        private readonly IConfiguracaoWhatsApp _configuracaoWhatsApp;
        private readonly ILogger<MetaApiService> _logger;
        public MetaApiService(IConfiguracaoWhatsApp configuracaoWhatsApp, ILogger<MetaApiService> logger)
        {
            _configuracaoWhatsApp = configuracaoWhatsApp;
            _logger = logger;
        }
        public async Task<RestResponse<T>> ChamarApiMeta<T>(String path, String body = "")
        {
            int maxTentativas = 3;
            int tentativas = 0;
            TimeSpan retryDelay;

            var options = new RestClientOptions(EndpointRequisicao.EnderecoBase)
            {
                Timeout = TimeSpan.FromSeconds(10)
            };
            var client = new RestClient(options);
            var request = new RestRequest(path, Method.Post);

            request.AddHeader("Authorization", $"Bearer {_configuracaoWhatsApp.TOKEN_USUARIO}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            while (tentativas < maxTentativas)
            {
                tentativas++;
                _logger.LogInformation($"Tentativa {tentativas} para o endpoint {request.Resource}");

                var response = await client.ExecutePostAsync<T>(request);

                if (response.IsSuccessful)
                    return response;

                retryDelay = TimeSpan.FromSeconds(Math.Pow(2, tentativas)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
                _logger.LogWarning($"Falha na tentativa {tentativas}. Aguardando {retryDelay} antes da próxima tentativa.");
                await Task.Delay(retryDelay);
            }
            _logger.LogError($"Número máximo de tentativas ({maxTentativas}) excedido para o endpoint {request.Resource}");
            throw new Exception("O limite máximo de tentativas foi atingido.");
        }

        public async Task<RestResponse<MensagemResposta>> EnviarMensagemRequisicao<MensagemResposta>((String numeroTelefone, String mensagem) parametros)
        {
            var body = new MensagemTextoRequisicao
            {
                MessagingProduct = "whatsapp",
                RecipientType = "individual",
                To = parametros.numeroTelefone,
                Type = "text",
                Text = new Texto
                {
                    PreviewUrl = false,
                    Body = parametros.mensagem
                }
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.EnviarMensagem);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<MensagemResposta>(pathBuilder.ToString(), bodyJson);
        }

        public async Task<RestResponse<MensagemResposta>> EnviarMensagemTemplateRequisicao<MensagemResposta>((String numeroTelefone, String nomeCliente, String mesCliente, String numeroContaCliente) parametros)
        {
            var body = new MensagemTemplateRequisicao
            {
                MessagingProduct = "whatsapp",
                RecipientType = "individual",
                To = parametros.numeroTelefone,
                Type = "template",
                Template = new Template
                {
                    Name = "modelo_teste",
                    Language = new Linguagem
                    {
                        Code = "pt_BR"
                    },
                    Components = new List<MensagemTextoComponente> {
                        new MensagemTextoComponente {
                            Type = "body",
                            Parameters = new List<MensagemTextoParametro>{
                                new MensagemTextoParametro{
                                    Type = "text",
                                    Text = parametros.nomeCliente
                                },
                                new MensagemTextoParametro{
                                    Type = "text",
                                    Text = parametros.mesCliente
                                },
                                new MensagemTextoParametro{
                                    Type= "text",
                                    Text = parametros.numeroContaCliente
                                }
                            }
                        }
                    }
                }
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.EnviarMensagem);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<MensagemResposta>(pathBuilder.ToString(), bodyJson);
        }
        public async Task<RestResponse<TelefoneCriarResposta>> TelefoneCriarRequisicao<TelefoneCriarResposta>((String codigoPais, String numeroTelefone, String nome) parametros)
        {
            var body = new TelefoneCriarRequisicao
            {
                CC = parametros.codigoPais,
                PhoneNumber = parametros.numeroTelefone,
                VerifiedName = parametros.nome
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.TelefoneCriar);
            pathBuilder.Replace("{{WHATSAPP_BUSINESS_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_ACCOUNT_ID);

            return await ChamarApiMeta<TelefoneCriarResposta>(pathBuilder.ToString(), bodyJson);
        }

        public async Task<RestResponse<TelefoneCodigoVerificacaoResposta>> TelefoneRequisitarCodigoRequisicao<TelefoneCodigoVerificacaoResposta>(String TELEFONE_ID)
        {
            var body = new TelefoneRequisitarCodigoRequisicao();

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.TelefoneRequisicaoCodigo);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<TelefoneCodigoVerificacaoResposta>(pathBuilder.ToString(), bodyJson);
        }

        public async Task<RestResponse<TelefoneVerificarCodigoResposta>> TelefoneVerificarCodigoRequisicao<TelefoneVerificarCodigoResposta>(String CodigoDeVerificacao)
        {
            var body = new TelefoneVerificarCodigoRequisicao
            {
                Code = CodigoDeVerificacao
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.TelefoneVerificarCodigo);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<TelefoneVerificarCodigoResposta>(pathBuilder.ToString(), bodyJson);
        }



        public async Task<RestResponse<TelefoneRegistroResposta>> TelefoneRegistrarRequisicao<TelefoneRegistroResposta>(String TELEFONE_ID)
        {
            var body = new TelefoneRegistrarRequisicao
            {
                Pin = "000000"
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.TelefoneRegistro);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<TelefoneRegistroResposta>(pathBuilder.ToString(), bodyJson);
        }

        public async Task<RestResponse<TelefoneRegistroResposta>> TelefoneExcluirRequisicao<TelefoneRegistroResposta>(String TELEFONE_ID)
        {
            var pathBuilder = new StringBuilder();

            pathBuilder.Append(EndpointRequisicao.TelefoneExcluirRegistro);
            pathBuilder.Replace("{{TELEFONE_ID}}", _configuracaoWhatsApp.WHATSAPP_BUSINESS_PHONE_ID);

            return await ChamarApiMeta<TelefoneRegistroResposta>(pathBuilder.ToString());
        }

    }
}