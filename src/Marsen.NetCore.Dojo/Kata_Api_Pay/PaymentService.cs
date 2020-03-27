using Marsen.NetCore.Dojo.Kata_Api_Pay.Interface;
using System.Net.Http;
using System.Text.Json;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay
{
    public class PaymentService
    {
        private readonly IHttpClient _httpClient;
        private readonly HttpClient _httpClient2;
        private readonly IConfigure _configure;

        public PaymentService(IHttpClient httpClient, IConfigure configure)
        {
            this._httpClient = httpClient;
            this._configure = configure;
        }

        public PaymentService(HttpClient httpClient2, IConfigure configure)
        {
            this._httpClient2 = httpClient2;
            this._configure = configure;
        }

        public void Pay(PayEntity payEntity)
        {
            var apiUrl = this._configure.Setting("PayService.Url");
            var requestId = this._httpClient2.GetAsync($"{apiUrl}requestId").Result.Content
                .ReadAsStringAsync().Result;
            HttpContent content = new StringContent(
                JsonSerializer.Serialize(
                    payEntity.RequestId = requestId));

            this._httpClient2.PostAsync($"{apiUrl}pay/CreditCard", content);
        }
    }
}