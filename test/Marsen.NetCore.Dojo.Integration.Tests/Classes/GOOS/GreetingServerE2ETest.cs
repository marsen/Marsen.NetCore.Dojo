using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.Classes.GOOS;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest : InitializationTest
    {
        private static readonly HttpClient GreetingServer = new() {BaseAddress = new Uri("http://localhost:8080/")};
        private string _queryString;

        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            GivenNowHourIs(15);
            GivenQueryStringAs("greeting");
            ResponseShouldBe("Hello World");
        }

        [Fact]
        public void Should_Greet_By_Name()
        {
            GivenNowHourIs(15);
            GivenQueryStringAs("greeting?Name=Mark");
            ResponseShouldBe("Hello Mark");
        }

        [Fact]
        public void Should_Sleep_At_14()
        {
            GivenNowHourIs(14);
            GivenQueryStringAs("greeting?Name=Mark");
            ResponseShouldBe("Zzz");
        }

        private void ResponseShouldBe(string response)
        {
            Assert.Equal(response, GetGreetingServerResult(_queryString));
        }

        private void GivenQueryStringAs(string queryString)
        {
            _queryString = queryString;
        }

        private static void GivenNowHourIs(int hours)
        {
            SystemDateTime.Now = new DateTime(2020, 11, 18, hours, 0, 0);
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
            GreetingServer.Main();
        }

        public void Dispose()
        {
            GreetingServer.Stop();
            SystemDateTime.Reset();
        }
    }
}