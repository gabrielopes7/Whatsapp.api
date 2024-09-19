using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Models.DTO
{
    public class TelefoneCriarDTO : BaseDTO
    {
        public required string CodigoDoPais { get; set; }
        public required string NomeEmpresa { get; set; }
    }
}