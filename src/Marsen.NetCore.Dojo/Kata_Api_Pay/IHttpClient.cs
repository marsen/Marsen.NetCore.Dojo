﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}