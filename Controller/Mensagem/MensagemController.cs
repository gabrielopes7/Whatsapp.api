using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models;
using System.Text.Json;
using Whatsapp.Microservice.Service.Interfaces;
using Whatsapp.Microservice.Models.Resposta.Mensagem;
using Whatsapp.Microservice.Models.Resposta;

namespace Whatsapp.Microservice.Controller
{
    [ApiController]
    [Route("api/mensagem")]
    public class MensagemController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        public MensagemController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("texto")]
        public async Task<IActionResult> EnviarMensagem(String numeroTelefoneCliente, String mensagem)
        {
            var parametros = (numeroTelefoneCliente, mensagem);

            RestResponse<MensagemResposta> response = await _metaApiService.EnviarMensagemRequisicao<MensagemResposta>(parametros);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            MensagemResposta mensagemResposta = response.Data ?? new MensagemResposta();

            return Ok(mensagemResposta);
        }
    }
}