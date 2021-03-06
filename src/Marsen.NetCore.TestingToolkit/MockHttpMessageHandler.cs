﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private readonly Dictionary<string, int> pathLookup = new Dictionary<string, int>();

        public string Input { get; private set; }
        public int NumberOfCalls { get; private set; }

        public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            CountRequest(request);

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

        private void CountRequest(HttpRequestMessage request)
        {
            if (pathLookup.ContainsKey($"{request.Method}:{request.RequestUri.AbsoluteUri}"))
            {
                pathLookup[$"{request.Method}:{request.RequestUri.AbsoluteUri}"]++;
            }
            else
            {
                pathLookup.Add($"{request.Method}:{request.RequestUri.AbsoluteUri}", 1);
            }
        }

        private int _times = 1;

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
            Assert.AreEqual(pathLookup[$"{method}:{path}"], _times);
        }
    }
}