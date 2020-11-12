using System;
using System.Net.Http;
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
        }
    }
}