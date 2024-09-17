using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Service
{
    // 
    //
    //
    //
    public class ConfiguracaoWhatsApp : IConfiguracaoWhatsApp
    {
        public string TOKEN_USUARIO { get; } = "EAAMBGUxmG4YBO2TaaZAHPZBHF3C7h1fnnQYuFeZAVx9B2KYCchQVI2m9G5fzI2Dp99SdkxEES9J4PMUHTXvjXN4gKIZChYm2PpqPEI8Am0OYXfDILybxBY4vsUHLSbIOwsW4qrpmR5IJCoxeW5Hr59hRLTeSD8LX0hoZC0cbYVD8O6LlSw4rqVrc01yU61ZBV7QgZDZD";
        public String BASE_URL { get; } = "https://graph.facebook.com/v20.0/";
        public String WHATSAPP_BUSINESS_PHONE_ID { get; } = "440371039150771";
        public String WHATSAPP_BUSINESS_ACCOUNT_ID { get; } = "433812176477492";
    }
}