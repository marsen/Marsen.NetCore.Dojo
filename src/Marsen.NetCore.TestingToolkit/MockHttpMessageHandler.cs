using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marsen.NetCore.TestingToolkit
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;
        private readonly Dictionary<string, int> _pathLookup = new();

        private int _times = 1;

        public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        private string Input { get; set; }
        public int NumberOfCalls { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            CountRequest(request);

            if (request.Content != null) // Could be a GET-request without a body
                Input = await request.Content.ReadAsStringAsync(cancellationToken);

            return new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            };
        }

        private void CountRequest(HttpRequestMessage request)
        {
            if (_pathLookup.ContainsKey($"{request.Method}:{request.RequestUri!.AbsoluteUri}"))
                _pathLookup[$"{request.Method}:{request.RequestUri.AbsoluteUri}"]++;
            else
                _pathLookup.Add($"{request.Method}:{request.RequestUri!.AbsoluteUri}", 1);
        }

        public MockHttpMessageHandler CallTimes(int i)
        {
            _times = i;
            return this;
        }

        public void AssertGet(string path)
        {
            AssertRequest("GET", path);
        }

        public void AssertPost(string path)
        {
            AssertRequest("POST", path);
        }

        private void AssertRequest(string method, string path)
        {
            Assert.AreEqual(_pathLookup[$"{method}:{path}"], _times);
        }
    }
}