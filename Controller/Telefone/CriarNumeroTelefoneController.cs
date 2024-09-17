using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
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
        public async Task<IActionResult> CriarNumeroTelefone(String codigoPais, String numeroTelefone, String nome)
        {
            var parametros = (codigoPais, numeroTelefone, nome);

            RestResponse<TelefoneCriarResposta> response = await _metaApiService.TelefoneCriarRequisicao<TelefoneCriarResposta>(parametros);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);
            
            TelefoneCriarResposta telefoneCriarResposta = response.Data ?? new TelefoneCriarResposta();

            return Ok(telefoneCriarResposta);
        }
    }
}