using System.Net.Http;
using System.Text.Json;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay
{
    public class PaymentService
    {
        private readonly IHttpClient _httpClient;

        public PaymentService(IHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public void Pay(PayEntity payEntity)
        {
            var requestId = this._httpClient.GetAsync("https://testing.url/api/v1/requestId").Result.Content
                .ReadAsStringAsync().Result;
            HttpContent content = new StringContent(
                JsonSerializer.Serialize(
                    payEntity.RequestId = requestId));

            this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", content);
        }
    }
}