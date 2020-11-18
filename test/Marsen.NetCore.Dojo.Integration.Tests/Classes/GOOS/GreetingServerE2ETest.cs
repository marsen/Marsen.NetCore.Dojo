﻿using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.Classes.GOOS;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest : InitializationTest
    {
        private static string _assumedHourOfDay = "9";
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
            _assumedHourOfDay ="14";
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
}