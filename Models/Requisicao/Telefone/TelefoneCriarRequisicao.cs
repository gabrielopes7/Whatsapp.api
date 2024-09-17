using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Telefone
{
    public class TelefoneCriar
    {
        [JsonPropertyName("cc")]
        public string? CC { get; set; }
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }
        [JsonPropertyName("verified_name")]
        public string? VerifiedName { get; set; }
    }
}