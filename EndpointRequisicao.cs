using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice
{
    public static class EndpointRequisicao
    {
        public static Uri EnderecoBase {get; private set;} = new Uri("https://graph.facebook.com/v20.0/");

        public static string TelefoneRegistro {get; private set;} = "{{Phone-Numbar-ID}}/register";
    }
}