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
            var apiUrl = "https://testing.url/api/v1/";
            var requestId = this._httpClient.GetAsync($"{apiUrl}requestId").Result.Content
                .ReadAsStringAsync().Result;
            HttpContent content = new StringContent(
                JsonSerializer.Serialize(
                    payEntity.RequestId = requestId));

            this._httpClient.PostAsync($"{apiUrl}pay/CreditCard", content);
        }
    }
}