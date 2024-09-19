namespace Whatsapp.Microservice.Models.DTO
{
    public class TemplateDTO : BaseDTO
    {
        public required string NomeTemplate { get; set; }
        public Dictionary<string, string>? ParametrosTemplate { get; set; } = [];
    }
}