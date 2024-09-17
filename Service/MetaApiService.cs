
using RestSharp;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Service
{
    public class MetaApiService : IMetaApiService
    {
        private readonly IConfiguracaoWhatsApp _configuracaoWhatsAppModel;
        public MetaApiService(IConfiguracaoWhatsApp configuracaoWhatsAppModel)
        {
            _configuracaoWhatsAppModel = configuracaoWhatsAppModel;
        }
        public async Task<RestResponse<T>> ChamarApiMeta<T>(String path, String body)
        {
            var options = new RestClientOptions(_configuracaoWhatsAppModel.BASE_URL);
            var client = new RestClient(options);
            var request = new RestRequest(path, Method.Post);

            request.AddHeader("Authorization", $"Bearer {_configuracaoWhatsAppModel.TOKEN_USUARIO}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            return await client.ExecutePostAsync<T>(request);
        }

    }
}