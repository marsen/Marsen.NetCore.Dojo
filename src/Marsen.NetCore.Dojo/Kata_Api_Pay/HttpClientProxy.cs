using System.Net.Http;
using System.Threading.Tasks;
using Marsen.NetCore.Dojo.Kata_Api_Pay.Interface;

namespace Marsen.NetCore.Dojo.Kata_Api_Pay
{
    public class HttpClientProxy : IHttpClient
    {
        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return new HttpClient().GetAsync(uri);
        }

        public Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            return new HttpClient().PostAsync(uri, content);
        }
    }
}