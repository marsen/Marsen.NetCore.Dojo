using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class PaymentServiceTests
    {
        [Fact]
        public void pay_should_Get_requestId()
        {
            IHttpClient httpClient = Substitute.For<IHttpClient>();
            var target = new PaymentService(httpClient);
            target.Pay();
            httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
        }
    }

    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }

    public class HttpClientProxy : IHttpClient
    {
        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return new HttpClient().GetAsync(uri);
        }
    }

    public class PaymentService
    {
        private readonly IHttpClient _httpClient;

        public PaymentService(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public void Pay()
        {
            this._httpClient.GetAsync("https://testing.url/api/v1/requestId");
        }
    }
}