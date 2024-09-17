using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Whatsapp.Microservice.Service.Interfaces;

namespace Whatsapp.Microservice.Service
{
    public class Hash256GenerateService : IHash256GenerateService
    {
        public string GerarSha256(String token, String palavraSecreta){
            string salt = token + palavraSecreta;

            using (SHA256 sha256 = SHA256.Create()){
                byte[] inputBytes = Encoding.UTF8.GetBytes(salt);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                foreach(byte byteCaract in hashBytes){
                    sb.Append(byteCaract.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}