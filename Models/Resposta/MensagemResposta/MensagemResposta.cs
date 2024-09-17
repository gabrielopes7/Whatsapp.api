using System.Text.Json.Serialization;

namespace Whatsapp.Microservice.Models.Resposta.Mensagem
{
    public class MensagemResposta
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; }
        [JsonPropertyName("contacts")]
        public List<Contato>? Contacts { get; set; }
        [JsonPropertyName("messages")]
        public List<Mensagem>? Messages { get; set; }
    }

    public class Contato
    {
        [JsonPropertyName("input")]
        public string? Input { get; set; }
        [JsonPropertyName("wa_id")]
        public string? WAID { get; set; }
    }

    public class Mensagem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}