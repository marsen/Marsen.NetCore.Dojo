using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class PaymentServiceTests
    {
        [Fact]
        public void pay_should_Get_requestId()
        {
            IHttpClient httpClient = null;
            var target = new PaymentService(httpClient);
            target.Pay();
            httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
        }
    }

    public interface IHttpClient
    {
        void GetAsync(string uri);
    }

    public class PaymentService
    {
        private readonly IHttpClient _httpClient;

        public PaymentService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }
    }
}