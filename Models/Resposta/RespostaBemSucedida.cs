using System.Text.Json.Serialization;

namespace Whatsapp.Microservice.Models.Resposta
{
    public class RespostaBemSucedida
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}