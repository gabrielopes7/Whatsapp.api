using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice
{
    public static class EndpointRequisicao
    {
        public static Uri EnderecoBase {get; private set;} = new Uri("https://graph.facebook.com/v20.0/");

        public static string EnviarMensagem {get; private set;} = "{{TELEFONE_ID}}/messages";
        public static string TelefoneCriar {get; private set;} = "{{WHATSAPP_BUSINESS_ID}}/phone_numbers";
        public static string TelefoneRegistro {get; private set;} = "{{TELEFONE_ID}}/register";
        public static string TelefoneRequisicaoCodigo {get; private set;} = "{{TELEFONE_ID}}/request_code";
        public static string TelefoneVerificarCodigo {get; private set;} = "{{TELEFONE_ID}}/verify_code";
        public static string TelefoneExcluirRegistro {get; private set;} = "{{TELEFONE_ID}}/deregister";
    }
}