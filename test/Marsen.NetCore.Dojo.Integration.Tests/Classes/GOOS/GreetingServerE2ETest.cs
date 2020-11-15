using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest : InitializationTest
    {
        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:8080/")};
            var response = httpClient.GetAsync("greeting").Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void Should_Greet_By_Name()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:8080/")};
            var response = httpClient.GetAsync("greeting?Name=Mark").Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Hello Mark", result);
        }
    }

    public class InitializationTest : IDisposable
    {
        protected InitializationTest()
        {
            GreetingServer.main();
        }
        public void Dispose()
        {
            GreetingServer.stop();
        }
    }


    public static class GreetingServer
    {
        private static HttpListener _httpListener;

        public static void main(params string[] args)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add($"http://+:8080/");
            _httpListener.Start();
            _httpListener.BeginGetContext(GetContext, _httpListener);
        }

        private static void GetContext(IAsyncResult ar)
        {
            if (ar.AsyncState is HttpListener httpListener)
            {
                HttpListenerContext context = httpListener.EndGetContext(ar); //接收到的請求context（一個環境封裝體）
                context.Response.ContentType = "html";
                context.Response.ContentEncoding = Encoding.UTF8;

                using var output = context.Response.OutputStream;
                var queryString = context.Request.QueryString["Name"];
                var response = "Hello World";
                if (string.IsNullOrEmpty(queryString)==false)
                {
                    response = "Hello Mark";
                }
                output.Write(Encoding.UTF8.GetBytes(response), 0, Encoding.UTF8.GetBytes(response).Length);
            }
        }

        public static void stop()
        {
            _httpListener.Stop();
        }
    }
}