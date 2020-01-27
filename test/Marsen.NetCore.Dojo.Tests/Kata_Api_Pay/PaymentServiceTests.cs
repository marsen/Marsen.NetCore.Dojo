using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Marsen.NetCore.Dojo.Kata_Api_Pay;
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
            this._configure = Substitute.For<IConfigure>();
            this._configure.Setting(Arg.Any<string>()).Returns(_testingApiUrl);
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
            var target = new PaymentService(_httpClient, _configure);
            target.Pay(new PayEntity());
        }


        private void ShouldGetRequestId()
        {
            this._httpClient.Received(1).GetAsync($"{_testingApiUrl}requestId");
        }

        private void ShouldPayByCreditCard()
        {
            this._httpClient.Received(1).PostAsync($"{_testingApiUrl}pay/CreditCard",
                Arg.Is<HttpContent>(x => x.ReadAsStringAsync().Result.Contains(_testRequestId)));
        }
    }
}