
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models;
using System.Text.Json;
using Whatsapp.Microservice.Service.Interfaces;
using Whatsapp.Microservice.Models.Resposta.Mensagem;
using Whatsapp.Microservice.Models.Resposta;

namespace Whatsapp.Microservice.Controller.Mensagem
{
    [ApiController]
    [Route("api/mensagem")]
    public class MensagemTemplateController : ControllerBase
    {
         private readonly IMetaApiService _metaApiService;
        public MensagemTemplateController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("template")]
        public async Task<IActionResult> EnviarTemplate(String numeroTelefoneCliente, String nomeCliente, String mes, String numeroConta)
        {
            var parametros = (numeroTelefoneCliente,nomeCliente, mes, numeroConta);

            RestResponse<MensagemResposta> response = await _metaApiService.EnviarMensagemTemplateRequisicao<MensagemResposta>(parametros);

            if (!response.IsSuccessful){
                RespostaErroWhatsApp responseError = JsonSerializer.Deserialize<RespostaErroWhatsApp>(response.Content!) ?? new RespostaErroWhatsApp();
                return BadRequest(responseError);
            }

            MensagemResposta mensagemResposta = response.Data ?? new MensagemResposta();

            return Ok(mensagemResposta);
        }
    }
}