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
    public class RegistrarNumeroController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        public RegistrarNumeroController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("registrarNumero")]
        public async Task<IActionResult> TelefoneRegistrar(String TELEFONE_ID)
        {
            RestResponse<TelefoneRegistrarResposta> response = await _metaApiService.TelefoneRegistrarRequisicao
            <TelefoneRegistrarResposta>(TELEFONE_ID);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneRegistrarResposta telefoneRegistrarResposta = response.Data ?? new TelefoneRegistrarResposta();

            return Ok(telefoneRegistrarResposta);
        }
    }
}