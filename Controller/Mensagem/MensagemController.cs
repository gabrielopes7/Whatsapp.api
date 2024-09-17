using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models;
using System.Text.Json;
using Whatsapp.Microservice.Service.Interfaces;
using Whatsapp.Microservice.Models.Resposta.Mensagem;
using Whatsapp.Microservice.Models.Requisicao.Mensagem;

namespace Whatsapp.Microservice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MensagemController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        private readonly IConfiguracaoWhatsApp _configuracaoWhatsAppModel;
        public MensagemController(IMetaApiService metaApiService, IConfiguracaoWhatsApp configuracaoWhatsAppModel)
        {
            _metaApiService = metaApiService;
            _configuracaoWhatsAppModel = configuracaoWhatsAppModel;
        }

        [HttpPost("enviarMensagem")]
        public async Task<IActionResult> EnviarMensagem(String numeroTelefoneCliente, String mensagem)
        {
            var body = new MensagemTextoRequisicao
            {
                MessagingProduct = "whatsapp",
                RecipientType = "individual",
                To = numeroTelefoneCliente,
                Type = "text",
                Text = new Text
                {
                    PreviewUrl = false,
                    Body = mensagem
                }
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<MensagemResposta> response = await _metaApiService.ChamarApiMeta<MensagemResposta>($"{_configuracaoWhatsAppModel.WHATSAPP_BUSINESS_PHONE_ID}/messages", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            MensagemResposta mensagemResposta = response.Data ?? new MensagemResposta();

            return Ok(mensagemResposta);
        }

        [HttpPost("enviarTemplate")]
        public async Task<IActionResult> EnviarTemplate(String numeroTelefoneCliente, String nomeCliente, String mes, String numeroConta)
        {
            var body = new MensagemTemplateRequisicao
            {
                MessagingProduct = "whatsapp",
                RecipientType = "individual",
                To = numeroTelefoneCliente,
                Type = "template",
                Template = new Template
                {
                    Name = "modelo_teste",
                    Language = new Language
                    {
                        Code = "pt_BR"
                    },
                    Components = new List<MensagemTextoComponente> {
                        new MensagemTextoComponente {
                            Type = "body",
                            Parameters = new List<MensagemTextoParametro>{
                                new MensagemTextoParametro{
                                    Type = "text",
                                    Text = nomeCliente
                                },
                                new MensagemTextoParametro{
                                    Type = "text",
                                    Text = mes
                                },
                                new MensagemTextoParametro{
                                    Type= "text",
                                    Text = numeroConta
                                }
                            }
                        }
                    }
                }
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<MensagemResposta> response = await _metaApiService.ChamarApiMeta<MensagemResposta>($"{_configuracaoWhatsAppModel.WHATSAPP_BUSINESS_PHONE_ID}/messages", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            MensagemResposta mensagemResposta = response.Data ?? new MensagemResposta();

            return Ok(mensagemResposta);
        }
    }
}