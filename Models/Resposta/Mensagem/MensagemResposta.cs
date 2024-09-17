using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Resposta.Mensagem
{
    public class MensagemResposta
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; }
        [JsonPropertyName("contacts")]
        public List<Contact>? Contacts { get; set; }
        [JsonPropertyName("messages")]
        public List<Message>? Messages { get; set; }
    }

    public class Contact
    {
        [JsonPropertyName("input")]
        public string? Input { get; set; }
        [JsonPropertyName("wa_id")]
        public string? WAID { get; set; }
    }

    public class Message
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}