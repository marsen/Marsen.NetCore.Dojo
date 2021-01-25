﻿using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.Classes.GOOS;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest : InitializationTest
    {
        private static readonly HttpClient GreetingServer = new() {BaseAddress = new Uri("http://localhost:8080/")};

        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            GiveNowHourIs(15);
            Assert.Equal("Hello World", GetGreetingServerResult("greeting"));
        }

        [Fact]
        public void Should_Greet_By_Name()
        {
            GiveNowHourIs(15);
            Assert.Equal("Hello Mark", GetGreetingServerResult("greeting?Name=Mark"));
        }

        [Fact]
        public void Should_Sleep_At_14()
        {
            GiveNowHourIs(14);
            Assert.Equal("Zzz", GetGreetingServerResult("greeting?Name=Mark"));
        }

        private static void GiveNowHourIs(int hours)
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
            GreetingServer.main();
        }

        public void Dispose()
        {
            GreetingServer.stop();
            SystemDateTime.Reset();
        }
    }
}