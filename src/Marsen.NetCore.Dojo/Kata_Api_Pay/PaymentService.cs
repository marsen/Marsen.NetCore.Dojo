using System.Net.Http;
using System.Net.Http.Headers;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay
{
    public class PaymentService
    {
        private readonly IHttpClient _httpClient;

        public PaymentService(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public void Pay()
        {
            var requestId = this._httpClient.GetAsync("https://testing.url/api/v1/requestId").Result.Content
                .ReadAsStringAsync().Result;
            this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", null);
        }
    }
}