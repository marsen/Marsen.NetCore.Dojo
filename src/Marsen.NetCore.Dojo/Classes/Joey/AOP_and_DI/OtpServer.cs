using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using Marsen.NetCore.Dojo.Common;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI
{
    public class OtpServer : IOtpServer
    {
        public string CurrentOtp(string accountId)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(SampleUri) };
            //// get the otp (One Time Password)
            var response = httpClient.PostAsync("api/otps", new StringContent(accountId)).Result;
            if (!response.IsSuccessStatusCode) throw new DojoException($"web api error, accountId:{accountId}");

            var currentOtp = response.Content.ReadAsStringAsync().Result;
            return currentOtp;
        }

        private static string SampleUri => "https://joey.com/";
    }
}