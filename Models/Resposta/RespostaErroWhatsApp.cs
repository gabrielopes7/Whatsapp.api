using System.Text.Json.Serialization;

namespace Whatsapp.Microservice.Models.Resposta
{
    public class RespostaErroWhatsApp
    {
        [JsonPropertyName("error")]
        public Error? Error { get; set; }
    }
    public class Error
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("error_subcode")]
        public int ErrorSubcode { get; set; }
        [JsonPropertyName("is_transient")]
        public bool IsTransient { get; set; }
        [JsonPropertyName("error_data")]
        public ErrorData? ErrorData { get; set; }
        [JsonPropertyName("error_user_title")]
        public string? ErrorUserTitle { get; set; }
        [JsonPropertyName("error_user_message")]
        public string? ErrorUserMessage { get; set; }
        [JsonPropertyName("fbtrace_id")]
        public string? FbtraceId { get; set; }

    }

    public class ErrorData
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; }

        [JsonPropertyName("details")]
        public string? Details { get; set; }
    }
}