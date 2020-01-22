using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Marsen.NetCore.Dojo.Kata_Api_Pay;
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

        [Fact]
        public void pay_should_Post_Pay_CreditCard()
        {
            IHttpClient httpClient = Substitute.For<IHttpClient>();
            var target = new PaymentService(httpClient);
            target.Pay();
            httpClient.Received().PostAsync("https://testing.url/api/v1/requestId", Arg.Any<HttpContent>());
        }
    }
}