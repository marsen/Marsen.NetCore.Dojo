using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Marsen.NetCore.TestingToolkit
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        public string Input { get; private set; }
        public int NumberOfCalls { get; private set; }
        private Dictionary<HttpRequestMessage, int> _requestTimesLookup = new Dictionary<HttpRequestMessage, int>();

        public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_requestTimesLookup.ContainsKey(request))
            {
                _requestTimesLookup[request]++;
            }
            else
            {
                _requestTimesLookup.Add(request, 1);
            }
            if (request.Content != null) // Could be a GET-request without a body
            {
                Input = await request.Content.ReadAsStringAsync();
            }

            return new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            };
        }
    }

    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool Received2(this MockHttpMessageHandler str, int i)
            {
                return str.NumberOfCalls == i;                
            }

            public static MockHttpMessageHandler Path(this MockHttpMessageHandler t)
            {
                return t;
            }
        }
    }
}