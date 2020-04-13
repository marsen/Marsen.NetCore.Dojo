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
            var isLocked = IsLocked(accountId);
            if (isLocked)
            {
                throw new FailedTooManyTimesException() {AccountId = accountId};
            }

            var passwordFromDb = PasswordFromDb(accountId);

            var hashedPassword = HashedPassword(password);

            var currentOtp = CurrentOtp(accountId);

            //// compare
            if (passwordFromDb == hashedPassword && currentOtp == otp)
            {
                ResetFailedCounter(accountId);
                return true;
            }
            else
            {
                AddFailedCounter(accountId);

                LogFailedCount(accountId);

                Notification(accountId);
                return false;
            }
        }

        private static void LogFailedCount(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            var failedCount = FailedCount(accountId, httpClient);
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info($"accountId:{accountId} failed times:{failedCount}");
        }

        private static void Notification(string accountId)
        {
            //// notify
            string message = $"account:{accountId} try to login failed";
            var slackClient = new SlackClient("my api token");
            slackClient.PostMessage(messageResponse => { }, "my channel", message, "my bot name");
        }

        private static string FailedCount(string accountId, HttpClient httpClient)
        {
            //// get failed counter
            var failedCountResponse =
                httpClient.PostAsync("api/failedCounter/GetFailedCount", new StringContent(accountId)).Result;

            failedCountResponse.EnsureSuccessStatusCode();

            var failedCount = failedCountResponse.Content.ReadAsStringAsync().Result;
            return failedCount;
        }

        private static void AddFailedCounter(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// add failed counter
            var addFailedCountResponse =
                httpClient.PostAsync("api/failedCounter/Add", new StringContent(accountId)).Result;
            addFailedCountResponse.EnsureSuccessStatusCode();
        }

        private static void ResetFailedCounter(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// reset failed counter
            var resetResponse = httpClient.PostAsync("api/failedCounter/Reset", new StringContent(accountId))
                .Result;
            resetResponse.EnsureSuccessStatusCode();
        }

        private static string CurrentOtp(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// get the otp (One Time Password)
            var response = httpClient.PostAsync("api/otps", new StringContent(accountId)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"web api error, accountId:{accountId}");
            }

            var currentOtp = response.Content.ReadAsStringAsync().Result;
            return currentOtp;
        }

        private static string HashedPassword(string password)
        {
            //// hash the password
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            var hashedPassword = hash.ToString();
            return hashedPassword;
        }

        private static bool IsLocked(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// check is locked
            var isLockedResponse =
                httpClient.PostAsync("api/failedCounter/IsLocked", new StringContent(accountId)).Result;
            isLockedResponse.EnsureSuccessStatusCode();
            var isLocked = isLockedResponse.Content.ReadAsStringAsync().Result == "true";
            return isLocked;
        }

        private static string PasswordFromDb(string accountId)
        {
            //// get the password from database
            string passwordFromDb;
            using (var connection = new SqlConnection("my connection string"))
            {
                passwordFromDb = connection
                    .Query<string>("spGetUserPassword", new {Id = accountId},
                        commandType: CommandType.StoredProcedure).SingleOrDefault();
            }

            return passwordFromDb;
        }
    }

    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; set; }
    }
}