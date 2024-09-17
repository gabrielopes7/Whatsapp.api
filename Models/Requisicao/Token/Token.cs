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

    /*
        curl -i -X POST "https://graph.facebook.com/v20.0/<CLIENT_BUSINESS_ID>/system_user_access_tokens
                        ?appsecret_proof=<APPSECRET_PROOF_HASH>
                        &access_token=<ACCESS_TOKEN>
                        &system_user_id=<SYSTEM_USER_ID>
                        &fetch_only=true"
    */
}