using System.Net.Http;
using System.Threading.Tasks;

namespace Marsen.NetCore.Dojo.Tests.Kata_Api_Pay
{
    public class HttpClientProxy : IHttpClient
    {
        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return new HttpClient().GetAsync(uri);
        }
    }
}