using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models.Resposta;
using Whatsapp.Microservice.Models.Resposta.Telefone;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Controller.Telefone
{
    [ApiController]
    [Route("api/telefone")]
    public class VerificarCodigoController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        public VerificarCodigoController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("verificarCodigo")]
        public async Task<IActionResult> VerificarCodigoTelefone(String CodigoDeVerificacao)
        {
           
            RestResponse<TelefoneVerificarCodigoResposta> response = await _metaApiService.TelefoneVerificarCodigoRequisicao<TelefoneVerificarCodigoResposta>(CodigoDeVerificacao);

            if (!response.IsSuccessful){
                RespostaErroWhatsApp responseError = JsonSerializer.Deserialize<RespostaErroWhatsApp>(response.Content!) ?? new RespostaErroWhatsApp();
                return BadRequest(responseError);
            }

            TelefoneVerificarCodigoResposta telefoneVerificarCodigoResposta = response.Data ?? new TelefoneVerificarCodigoResposta();
            
            return Ok(telefoneVerificarCodigoResposta);
        }
    }
}