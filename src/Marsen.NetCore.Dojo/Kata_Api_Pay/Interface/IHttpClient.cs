﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay.Interface
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);
    }
}