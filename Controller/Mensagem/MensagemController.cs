using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models;
using System.Text.Json;
using Whatsapp.Microservice.Service.Interfaces;
using Whatsapp.Microservice.Models.Resposta.Mensagem;
using Whatsapp.Microservice.Models.Resposta;
using Whatsapp.Microservice.Models.DTO;

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
        public async Task<IActionResult> EnviarMensagem([FromBody] MensagemDTO mensagemDTO)
        {
            RestResponse<MensagemResposta> response = await _metaApiService.EnviarMensagemRequisicao<MensagemResposta>(mensagemDTO);

            if (!response.IsSuccessful){
                RespostaErroWhatsApp responseError = JsonSerializer.Deserialize<RespostaErroWhatsApp>(response.Content!) ?? new RespostaErroWhatsApp();
                return BadRequest(responseError);
            }

            MensagemResposta mensagemResposta = response.Data ?? new MensagemResposta();

            return Ok(mensagemResposta);
        }
    }
}