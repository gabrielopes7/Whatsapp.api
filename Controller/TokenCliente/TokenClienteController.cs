using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Whatsapp.Microservice.Models.Token;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Controller.TokenCliente
{
    [ApiController]
    [Route("[controller]")]
    public class TokenClienteController : ControllerBase
    {
        private readonly String _CLIENT_BUSINESS_ID = "702361225431831";
        private readonly String _APPSECRET = "21c861e636726374f6a2349c84d696c0";
        private readonly String _TOKENCLIENTE = "e1e9bdf989d5caa632b0258af63c931f6";
        private readonly String _TOKENPERM = "EAAMBGUxmG4YBOZBJrju8DxLCWaUcsEZCh6LohHDqUPRi8yrtZBJE4ct9E496thKaZBACZC0UMZC0d73U8H9k1ndbdRfzVAjfizZBpTf3DGvuGPTzsaJ2btln5tziNsqlBT98t65AmbQoZBHSSVzWYAPK53a3EFZAobKt15kQoanWYAqzxbCpagtW1ak9LTAAbUoShHgZDZD";
        private readonly IHash256GenerateService _hash256GenerateService;
        private readonly IMetaApiService _metaApiService;
        public TokenClienteController(IHash256GenerateService hash256GenerateService, IMetaApiService metaApiService){
            _hash256GenerateService = hash256GenerateService;
            _metaApiService = metaApiService;
        }

        
        [HttpPost("buscarTokenCliente")]
        public async Task<IActionResult> BuscarTokenCliente(){
            string appsecret_proof = _hash256GenerateService.GerarSha256(_TOKENPERM, _APPSECRET);
            
            var body = new Token
            {
                AppSecretProof = appsecret_proof,
                AccessToken = _TOKENPERM,
                SystemUserId = "61565621615528",
                FetchOnly = true
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            //RestResponse response = await _metaApiService.ChamarApiMeta($"{_CLIENT_BUSINESS_ID}/system_user_access_tokens", bodyJson);

            // if (!response.IsSuccessful)
            //     return BadRequest(response.Content);

            return Ok();
        }
    }
}