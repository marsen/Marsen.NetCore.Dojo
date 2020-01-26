using System.Net.Http;
using System.Threading.Tasks;
using Marsen.NetCore.Dojo.Kata_Api_Pay;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class PaymentServiceTests
    {
        private readonly IHttpClient _httpClient;

        private string _testRequestId = "Test_Request_Id";

        private string _testingApiUrl = "https://testing.url/api/v1/";

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
        }


        [Fact]
        public void pay_should_Get_requestId()
        {
            WhenPay();
            this._httpClient.Received().GetAsync($"{_testingApiUrl}requestId");
        }

        [Fact]
        public void pay_should_Post_Pay_CreditCard()
        {
            WhenPay();
            this._httpClient.Received().PostAsync($"{_testingApiUrl}pay/CreditCard", Arg.Any<HttpContent>());
        }

        [Fact]
        public void pay_should_Get_RequestId_Before_Post_Pay_CreditCard()
        {
            WhenPay();
            Received.InOrder(() =>
            {
                this._httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
                this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", Arg.Any<HttpContent>());
            });
        }

        private void WhenPay()
        {
            var target = new PaymentService(_httpClient);
            target.Pay();
        }
    }
}