using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Service.Interfaces
{
    public interface IHash256GenerateService
    {
        public string GerarSha256(String token, String palavraSecreta);
    }
}