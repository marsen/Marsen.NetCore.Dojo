namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
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
            this._httpClient.GetAsync("https://testing.url/api/v1/requestId");
        }
    }
}