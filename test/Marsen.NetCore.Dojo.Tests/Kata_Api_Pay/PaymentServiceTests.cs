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
        IHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentServiceTests" /> class.
        /// </summary>
        public PaymentServiceTests()
        {
            httpClient = Substitute.For<IHttpClient>();
        }

        [Fact]
        public void pay_should_Get_requestId()
        {
            //IHttpClient httpClient = Substitute.For<IHttpClient>();
            //var target = new PaymentService(httpClient);
            //target.Pay();
            WhenPay();
            httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
        }

        [Fact]
        public void pay_should_Post_Pay_CreditCard()
        {
            WhenPay();
            httpClient.Received().PostAsync("https://testing.url/api/v1/pay/CreditCard", Arg.Any<HttpContent>());
        }

        private void WhenPay()
        {
            //IHttpClient httpClient = Substitute.For<IHttpClient>();
            var target = new PaymentService(httpClient);
            target.Pay();
        }
    }
}