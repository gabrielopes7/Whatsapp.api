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
    public class RequisitarCodigoController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        public RequisitarCodigoController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("requisitarCodigo")]
        public async Task<IActionResult> RequisitarCodigo(String TELEFONE_ID)
        {
            RestResponse<TelefoneRequisitarCodigoResposta> response = await _metaApiService.TelefoneRequisitarCodigoRequisicao<TelefoneRequisitarCodigoResposta>(TELEFONE_ID);

            if (!response.IsSuccessful){
                RespostaErroWhatsApp responseError = JsonSerializer.Deserialize<RespostaErroWhatsApp>(response.Content!) ?? new RespostaErroWhatsApp();
                return BadRequest(responseError);
            }

            TelefoneRequisitarCodigoResposta telefoneRequisitarCodigoResposta = response.Data ?? new TelefoneRequisitarCodigoResposta();
            
            return Ok(telefoneRequisitarCodigoResposta);
        }
    }
}