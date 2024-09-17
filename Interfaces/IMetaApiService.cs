using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Whatsapp.Microservice.Service.Interfaces
{
    public interface IMetaApiService
    {
        public Task<RestResponse<T>> ChamarApiMeta<T>(String path, String body = "");
    }
}