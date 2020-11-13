using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest
    {
        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            GreetingServer.main();
            var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:8080/")};
            var response = httpClient.GetAsync("posts").Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Hello World",result);
        }
        
    }

    public static class GreetingServer
    {
        public static void main(params string[] args)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add($"http://+:8080/");
            httpListener.Start();
            httpListener.BeginGetContext(GetContext, httpListener);
        }

        private static void GetContext(IAsyncResult ar)
        {
            if (ar.AsyncState is HttpListener httpListener)
            {
                HttpListenerContext context = httpListener.EndGetContext(ar); //接收到的請求context（一個環境封裝體）
                context.Response.ContentType = "html";
                context.Response.ContentEncoding = Encoding.UTF8;

                using var output = context.Response.OutputStream;
                var response = "Hello World";
                output.Write(Encoding.UTF8.GetBytes(response), 0, Encoding.UTF8.GetBytes(response).Length);
            }
        }
    }
}