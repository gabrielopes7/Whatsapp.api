using System.Text.Json.Serialization;

namespace Whatsapp.Microservice.Models.Resposta
{
    public class RepostaBemSucedida
    {
        [JsonPropertyName("success")]
        public bool Sucesso { get; set; }
    }
}