using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models.DTO;
using Whatsapp.Microservice.Models.Resposta;
using Whatsapp.Microservice.Models.Resposta.Telefone;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Controller.Telefone
{
    [ApiController]
    [Route("api/telefone")]
    public class CriarNumeroTelefoneController : ControllerBase
    {
        
        private readonly IMetaApiService _metaApiService;
        public CriarNumeroTelefoneController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("criarNumeroTelefone")]
        public async Task<IActionResult> CriarNumeroTelefone([FromBody] TelefoneCriarDTO telefoneCriarDTO)
        {
            RestResponse<TelefoneCriarResposta> response = await _metaApiService.TelefoneCriarRequisicao<TelefoneCriarResposta>(telefoneCriarDTO);

            if (!response.IsSuccessful){
                RespostaErroWhatsApp responseError = JsonSerializer.Deserialize<RespostaErroWhatsApp>(response.Content!) ?? new RespostaErroWhatsApp();
                return BadRequest(responseError);
            }
            
            TelefoneCriarResposta telefoneCriarResposta = response.Data ?? new TelefoneCriarResposta();

            return Ok(telefoneCriarResposta);
        }
    }
}