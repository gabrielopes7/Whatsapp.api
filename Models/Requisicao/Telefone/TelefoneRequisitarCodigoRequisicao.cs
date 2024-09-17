using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Telefone
{
    public class TelefoneRequisitarCodigoRequisicao
    {
        [JsonPropertyName("code_method")]
        public string CodeMethod {get;set;} = "SMS";
        [JsonPropertyName("language")]
        public string Language {get;set;} = "pt_BR";
    }
}