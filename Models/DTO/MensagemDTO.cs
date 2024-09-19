using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.DTO
{
    public class MensagemDTO : BaseDTO
    {
        
        // Posteriormente poderá ser implementado os Type para envio de Áudio, entre outros.
        public required string MensagemParaEnvio { get; set; }
    }
}