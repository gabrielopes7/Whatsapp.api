using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsapp.Microservice.Service.Interfaces
{
    public interface IConfiguracaoWhatsApp
    {
        public string TOKEN_USUARIO { get;}
        public string BASE_URL { get;}
        public string WHATSAPP_BUSINESS_PHONE_ID { get;}
        public string WHATSAPP_BUSINESS_ACCOUNT_ID { get;}
    }
}