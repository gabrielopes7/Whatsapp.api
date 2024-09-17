using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Telefone
{
    public class TelefoneVerificarCodigo
    {
        [JsonPropertyName("code")]
        public string? Code {get;set;}
    }
}