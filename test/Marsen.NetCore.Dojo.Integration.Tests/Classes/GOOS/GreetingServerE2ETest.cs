using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest : InitializationTest
    {
        private static string assumedHourOfDay = "9";
        private static readonly HttpClient GreetingServer = new HttpClient
            {BaseAddress = new Uri("http://localhost:8080/")};

        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            Assert.Equal("Hello World", GetGreetingServerResult("greeting"));
        }

        [Fact]
        public void Should_Greet_By_Name()
        {
            Assert.Equal("Hello Mark", GetGreetingServerResult("greeting?Name=Mark"));
        }

        [Fact]
        public void Should_Sleep_At_14()
        {
            assumedHourOfDay ="14";
            Assert.Equal("Zzz", GetGreetingServerResult("greeting?Name=Mark"));
        }


        private static string GetGreetingServerResult(string requestUri)
        {
            var response = GreetingServer.GetAsync(requestUri).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
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
                var response = new Greeter().Invoke(context.Request.QueryString["Name"]);
                output.Write(Encoding.UTF8.GetBytes(response), 0, Encoding.UTF8.GetBytes(response).Length);
            }
        }

        public static void stop()
        {
            _httpListener.Stop();
        }
    }

    public class GreeterTest
    {
        [Fact]
        public void GreetByName()
        {
            Assert.Equal("Hello Jones", new Greeter().Invoke("Jones"));
        }
    }

    public class Greeter
    {
        public string Invoke(string name)
        {
            var response = "Hello World";
            if (string.IsNullOrEmpty(name) == false)
            {
                response = $"Hello {name}";
            }

            return response;
        }
    }
}