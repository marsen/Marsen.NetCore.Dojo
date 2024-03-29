﻿using System.Net;
using System.Net.Http;
using Marsen.NetCore.Dojo.Kata.Api_Pay;
using Marsen.NetCore.Dojo.Kata.Api_Pay.Interface;
using Marsen.NetCore.TestingToolkit;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Api_Pay
{
    public class PaymentServiceTests
    {
        private const string _testRequestId = "Test_Request_Id";
        private const string _testingApiUrl = "https://testing.url/api/v1/";
        private readonly IConfigure _configure;
        private MockHttpMessageHandler _mockHttpMessageHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaymentServiceTests" /> class.
        /// </summary>
        public PaymentServiceTests()
        {
            _configure = Substitute.For<IConfigure>();
            _configure.Setting("PayService.Url").Returns(_testingApiUrl);
        }

        [Fact]
        public void pay_should_Get_requestId()
        {
            WhenPay();
            ShouldGetRequestId();
        }

        [Fact]
        public void pay_should_Post_Pay_CreditCard()
        {
            WhenPay();
            ShouldPayByCreditCard();
        }

        [Fact]
        public void pay_should_Get_RequestId_Before_Post_Pay_CreditCard()
        {
            WhenPay();
            Received.InOrder(() =>
            {
                ShouldGetRequestId();
                ShouldPayByCreditCard();
            });
        }

        private void WhenPay()
        {
            _mockHttpMessageHandler = new MockHttpMessageHandler(_testRequestId, HttpStatusCode.OK);
            var target = new PaymentService(_configure)
            {
                httpClient = new HttpClient(_mockHttpMessageHandler)
            };
            target.Pay(new PayEntity());
        }

        private void ShouldGetRequestId()
        {
            _mockHttpMessageHandler.CallTimes(1).AssertGet($"{_testingApiUrl}requestId");
        }

        private void ShouldPayByCreditCard()
        {
            _mockHttpMessageHandler.CallTimes(1).AssertPost($"{_testingApiUrl}pay/CreditCard");
        }
    }
}