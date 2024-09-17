using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Whatsapp.Microservice.Models.Telefone
{
    public class TelefoneRegistrarRequisicao
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct {get;private set;} = "whatsapp";
        [JsonPropertyName("pin")]
        public string? Pin {get;set;}
    }
}