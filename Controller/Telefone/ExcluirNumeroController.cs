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
    public class ExcluirNumeroController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        public ExcluirNumeroController(IMetaApiService metaApiService)
        {
            _metaApiService = metaApiService;
        }

        [HttpPost("excluirNumero")]
        public async Task<IActionResult> TelefoneExcluir(String TELEFONE_ID)
        {
            RestResponse<TelefoneExcluirResposta> response = await _metaApiService.TelefoneExcluirRequisicao<TelefoneExcluirResposta>(TELEFONE_ID);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneExcluirResposta telefoneExcluirRegistroResposta = response.Data ?? new TelefoneExcluirResposta();

            return Ok(telefoneExcluirRegistroResposta);
        }
    }
}