
using System.Text.Json.Serialization;

namespace Whatsapp.Microservice.Models.Requisicao
{
    public class MensagemTextoRequisicao
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; } = "whatsapp";
        [JsonPropertyName("recipient_type")]
        public string? RecipientType { get; set; } = "individual";
        [JsonPropertyName("to")]
        public string? To { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; } = "text";
        [JsonPropertyName("text")]
        public Texto? Text { get; set; }
    }

    public class Texto
    {
        [JsonPropertyName("preview_url")] 
        public bool PreviewUrl { get; set; }
        [JsonPropertyName("body")] 
        public string? Body { get; set; }
    }
}