using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Marsen.NetCore.Dojo.Kata_Api_Pay;
using Marsen.NetCore.Dojo.Kata_Api_Pay.Interface;
using Marsen.NetCore.TestingToolkit;
using Marsen.NetCore.TestingToolkit.ExtensionMethods;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class PaymentServiceTests
    {
        private readonly IHttpClient _httpClient;

        private readonly IConfigure _configure;

        private readonly string _testRequestId = "Test_Request_Id";

        private readonly string _testingApiUrl = "https://testing.url/api/v1/";
        private readonly HttpClient _httpClient2;
        private readonly MockHttpMessageHandler _mockHttpMessageHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentServiceTests" /> class.
        /// </summary>
        public PaymentServiceTests()
        {
            this._httpClient = Substitute.For<IHttpClient>();
            this._httpClient.GetAsync(Arg.Any<string>()).ReturnsForAnyArgs(
                Task.FromResult(
                    new HttpResponseMessage
                    {
                        Content = new StringContent(_testRequestId)
                    }));
            _mockHttpMessageHandler = new MockHttpMessageHandler(_testRequestId, HttpStatusCode.OK);
            this._httpClient2 = new HttpClient(_mockHttpMessageHandler);
            this._configure = Substitute.For<IConfigure>();
            this._configure.Setting("PayService.Url").Returns(_testingApiUrl);
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
            var target = new PaymentService(_httpClient2, _configure);
            target.Pay(new PayEntity());
        }


        private void ShouldGetRequestId()
        {
            Assert.True(_mockHttpMessageHandler.Path().CallTimes(1));
            ///this._httpClient2.GetAsync($"{_testingApiUrl}requestId");
        }

        private void ShouldPayByCreditCard()
        {
            this._httpClient.Received(1).PostAsync($"{_testingApiUrl}pay/CreditCard",
                Arg.Is<HttpContent>(x => x.ReadAsStringAsync().Result.Contains(_testRequestId)));
        }
    }
}