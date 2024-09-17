using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using Whatsapp.Microservice.Models.Resposta.Telefone;
using Whatsapp.Microservice.Models.Telefone;
using Whatsapp.Microservice.Service;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly IMetaApiService _metaApiService;
        private readonly IConfiguracaoWhatsApp _configuracaoWpp;
        public TelefoneController(IMetaApiService metaApiService, IConfiguracaoWhatsApp configuracaoWhatsAppModel)
        {
            _metaApiService = metaApiService;
            _configuracaoWpp = configuracaoWhatsAppModel;
        }

        [HttpPost("criarNumeroTelefone")]
        public async Task<IActionResult> CriarNumeroTelefone(String CodigoPais, String NumeroTelefone, String Nome)
        {
            var body = new TelefoneCriar
            {
                CC = CodigoPais,
                PhoneNumber = NumeroTelefone,
                VerifiedName = Nome
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<TelefoneCriarResposta> response = await _metaApiService.ChamarApiMeta<TelefoneCriarResposta>($"{_configuracaoWpp.WHATSAPP_BUSINESS_ACCOUNT_ID}/phone_numbers", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);
            
            TelefoneCriarResposta telefoneCriarResposta = response.Data ?? new TelefoneCriarResposta();

            return Ok(telefoneCriarResposta);
        }

        [HttpPost("requisicaoCodigo")]
        public async Task<IActionResult> RequisicaoCodigoTelefone(String IdTelefoneWhatsAppBusiness)
        {

            var body = new TelefoneRequisicaoCodigo();

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<TelefoneRequisicaoCodigoResposta> response = await _metaApiService.ChamarApiMeta<TelefoneRequisicaoCodigoResposta>($"{IdTelefoneWhatsAppBusiness}/request_code", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneRequisicaoCodigoResposta telefoneRequisicaoCodigoResposta = response.Data ?? new TelefoneRequisicaoCodigoResposta();
            
            return Ok(telefoneRequisicaoCodigoResposta);
        }

        [HttpPost("verificarCodigo")]
        public async Task<IActionResult> VerificarCodigoTelefone(String CodigoDeVerificacao)
        {
            var body = new TelefoneVerificarCodigo
            {
                Code = CodigoDeVerificacao
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<TelefoneVerificarCodigoResposta> response = await _metaApiService.ChamarApiMeta<TelefoneVerificarCodigoResposta>($"{_configuracaoWpp.WHATSAPP_BUSINESS_PHONE_ID}/verify_code", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneVerificarCodigoResposta telefoneVerificarCodigoResposta = response.Data ?? new TelefoneVerificarCodigoResposta();
            
            return Ok(telefoneVerificarCodigoResposta);
        }

        [HttpPost("registrarWhatsappBusiness")]
        public async Task<IActionResult> TelefoneRegistro(String IdTelefoneWhatsAppBusiness)
        {

            var body = new TelefoneRegistro
            {
                Pin = "000000"
            };

            string bodyJson = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });

            RestResponse<TelefoneRegistroResposta> response = await _metaApiService.ChamarApiMeta<TelefoneRegistroResposta>($"{IdTelefoneWhatsAppBusiness}/register", bodyJson);

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneRegistroResposta telefoneRegistroResposta = response.Data ?? new TelefoneRegistroResposta();

            return Ok(telefoneRegistroResposta);
        }

        [HttpPost("excluirWhatsappBusiness")]
        public async Task<IActionResult> TelefoneExcluir(String IdTelefoneWhatsAppBusiness)
        {
            RestResponse<TelefoneExcluirRegistroResposta> response = await _metaApiService.ChamarApiMeta<TelefoneExcluirRegistroResposta>($"{IdTelefoneWhatsAppBusiness}/deregister");

            if (!response.IsSuccessful)
                return BadRequest(response.Content);

            TelefoneExcluirRegistroResposta telefoneExcluirRegistroResposta = response.Data ?? new TelefoneExcluirRegistroResposta();

            return Ok(telefoneExcluirRegistroResposta);
        }
    }
}