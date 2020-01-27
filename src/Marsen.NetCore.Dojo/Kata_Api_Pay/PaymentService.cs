using System.Net.Http;
using System.Net.Http.Headers;
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

        public void Pay()
        {
            var requestId = this._httpClient.GetAsync("https://testing.url/api/v1/requestId").Result.Content
                .ReadAsStringAsync().Result;
            HttpContent content = new StringContent(JsonSerializer.Serialize(new PayEntity {RequestId = requestId}));
            this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", content);
        }
    }
}