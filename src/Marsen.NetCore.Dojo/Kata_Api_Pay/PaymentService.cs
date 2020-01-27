using System.Net.Http;
using System.Text.Json;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay
{
    public class PaymentService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfigure _configure;

        public PaymentService(IHttpClient httpClient, IConfigure configure)
        {
            this._httpClient = httpClient;
            this._configure = configure;
        }

        public void Pay(PayEntity payEntity)
        {
            //var apiUrl = "https://testing.url/api/v1/";
            var apiUrl = this._configure.Setting("PayService.Url");
            var requestId = this._httpClient.GetAsync($"{apiUrl}requestId").Result.Content
                .ReadAsStringAsync().Result;
            HttpContent content = new StringContent(
                JsonSerializer.Serialize(
                    payEntity.RequestId = requestId));

            this._httpClient.PostAsync($"{apiUrl}pay/CreditCard", content);
        }
    }

    public interface IConfigure
    {
        string Setting(string key);
    }
}