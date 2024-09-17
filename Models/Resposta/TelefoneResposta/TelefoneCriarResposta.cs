using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Resposta.Telefone
{
    public class TelefoneCriarResposta
    {
        [JsonPropertyName("id")]
        public String? Id { get; set; }
    }
}