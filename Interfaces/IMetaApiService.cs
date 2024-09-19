using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Whatsapp.Microservice.Models.DTO;
using Whatsapp.Microservice.Models.Resposta;
using Whatsapp.Microservice.Models.Resposta.Mensagem;
using Whatsapp.Microservice.Models.Resposta.Telefone;

namespace Whatsapp.Microservice.Service.Interfaces
{
    public interface IMetaApiService
    {
        public Task<RestResponse<T>> ChamarApiMeta<T>(String path, String body = "");
        public Task<RestResponse<MensagemResposta>> EnviarMensagemRequisicao<MensagemResposta>(MensagemDTO mensagemDTO);
        public Task<RestResponse<MensagemResposta>> EnviarMensagemTemplateRequisicao<MensagemResposta>(TemplateDTO templateDTO);
        public Task<RestResponse<TelefoneCriarResposta>> TelefoneCriarRequisicao<TelefoneCriarResposta>(TelefoneCriarDTO telefoneCriarDTO);
        public Task<RestResponse<TelefoneRequisitarCodigoResposta>> TelefoneRequisitarCodigoRequisicao<TelefoneRequisitarCodigoResposta>(String TELEFONE_ID);
        public Task<RestResponse<TelefoneVerificarCodigoResposta>> TelefoneVerificarCodigoRequisicao<TelefoneVerificarCodigoResposta>(String CodigoDeVerificacao);
        public Task<RestResponse<TelefoneRegistrarResposta>> TelefoneRegistrarRequisicao<TelefoneRegistrarResposta>(String TELEFONE_ID);
        public Task<RestResponse<TelefoneExcluirResposta>> TelefoneExcluirRequisicao<TelefoneExcluirResposta>(String TELEFONE_ID);
    }
}