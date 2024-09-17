using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.Requisicao
{
    public class MensagemTemplateRequisicao
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; } = "whatsapp";
        [JsonPropertyName("recipient_type")]
        public string? RecipientType { get; set; } = "individual";
        [JsonPropertyName("to")]
        public string? To { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; } = "text";
        [JsonPropertyName("template")]
        public Template? Template { get; set; }
    }

    public class Template
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("language")]
        public Linguagem? Language { get; set; }
        [JsonPropertyName("components")]
        public List<MensagemTextoComponente>? Components { get; set; }
    }

    public class MensagemTextoComponente
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("parameters")]
        public List<MensagemTextoParametro>? Parameters { get; set; }
    }

    public class MensagemTextoParametro
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("image")]
        public ImagemTemplate? Image { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("currency")]
        public MoedaTemplate? Currency { get; set; }

        [JsonPropertyName("date_time")]
        public DataTemplate? DateTime { get; set; }
    }

    public class MoedaTemplate
    {
        [JsonPropertyName("fallback_value")]
        public string? FallbackValue { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("amount_1000")]
        public long Amount1000 { get; set; }
    }

    public class DataTemplate
    {
        [JsonPropertyName("fallback_value")]
        public string? FallbackValue { get; set; }

        [JsonPropertyName("day_of_week")]
        public long DayOfWeek { get; set; }

        [JsonPropertyName("year")]
        public long Year { get; set; }

        [JsonPropertyName("month")]
        public long Month { get; set; }

        [JsonPropertyName("day_of_month")]
        public long DayOfMonth { get; set; }

        [JsonPropertyName("hour")]
        public long Hour { get; set; }

        [JsonPropertyName("minute")]
        public long Minute { get; set; }

        [JsonPropertyName("calendar")]
        public string? Calendar { get; set; }
    }

    public class ImagemTemplate
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("caption")]
        public string? Caption { get; set; }
    }
    public class Linguagem
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}