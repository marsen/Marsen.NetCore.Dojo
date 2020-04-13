using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using Dapper;
using SlackAPI;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService
    {
        public bool Verify(string accountId, string password, string otp)
        {            
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};            

            //// check is locked
            var isLockedResponse = httpClient.PostAsync("api/failedCounter/IsLocked",new StringContent(accountId)).Result;
            isLockedResponse.EnsureSuccessStatusCode();
            if (isLockedResponse.Content.ReadAsStringAsync().Result == "true")
            {
                throw new FailedTooManyTimesException() {AccountId = accountId};
            }

            //// get the password from database
            string passwordFromDb = string.Empty;
            using (var connection = new SqlConnection("my connection string"))
            {
                passwordFromDb = connection
                    .Query<string>("spGetUserPassword", new { Id = accountId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }

            //// hash the password
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            var hashedPassword = hash.ToString();

            //// get the otp (One Time Password)
            var response = httpClient.PostAsync("api/otps", new StringContent(accountId)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"web api error, accountId:{accountId}");
            }

            var currentOtp = response.Content.ReadAsStringAsync().Result;

            //// compare
            if (passwordFromDb == hashedPassword && currentOtp == otp)
            {
                //// reset failed counter
                var resetResponse = httpClient.PostAsync("api/failedCounter/Reset",new StringContent(accountId)).Result;
                resetResponse.EnsureSuccessStatusCode();
                return true;
            }
            else
            {
                //// add failed counter
                var addFailedCountResponse = httpClient.PostAsync("api/failedCounter/Add", new StringContent(accountId)).Result;
                addFailedCountResponse.EnsureSuccessStatusCode();

                //// get failed counter
                var failedCountResponse =
                    httpClient.PostAsync("api/failedCounter/GetFailedCount", new StringContent(accountId)).Result;

                failedCountResponse.EnsureSuccessStatusCode();

                var failedCount = failedCountResponse.Content.ReadAsStringAsync().Result;
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Info($"accountId:{accountId} failed times:{failedCount}");

                //// notify
                string message = $"account:{accountId} try to login failed";
                var slackClient = new SlackClient("my api token");
                slackClient.PostMessage(messageResponse => { }, "my channel", message, "my bot name");
                return false;
            }
        }
    }

    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; set; }
    }
}