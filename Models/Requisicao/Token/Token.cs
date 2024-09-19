using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Token
{
    public class Token
    {
        [JsonPropertyName("appsecret_proof")]
        public string? AppSecretProof { get; set; }
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("system_user_id")]
        public string? SystemUserId { get; set; }
        [JsonPropertyName("fetch_only")]
        public Boolean FetchOnly { get; set; }
    }
}