using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AccountService : IAccountService
    {
        public bool IsLocked(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// check is locked
            var isLockedResponse =
                httpClient.PostAsync("api/failedCounter/IsLocked", new StringContent(accountId)).Result;
            isLockedResponse.EnsureSuccessStatusCode();
            var isLocked = isLockedResponse.Content.ReadAsStringAsync().Result == "true";
            return isLocked;
        }

        public void ResetFailedCounter(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// reset failed counter
            var resetResponse = httpClient.PostAsync("api/failedCounter/Reset", new StringContent(accountId))
                .Result;
            resetResponse.EnsureSuccessStatusCode();
        }

        public void AddFailedCounter(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// add failed counter
            var addFailedCountResponse =
                httpClient.PostAsync("api/failedCounter/Add", new StringContent(accountId)).Result;
            addFailedCountResponse.EnsureSuccessStatusCode();
        }

        public string FailedCount(string accountId)
        {
            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            //// get failed counter
            var failedCountResponse =
                httpClient.PostAsync("api/failedCounter/GetFailedCount", new StringContent(accountId)).Result;

            failedCountResponse.EnsureSuccessStatusCode();

            var failedCount = failedCountResponse.Content.ReadAsStringAsync().Result;
            return failedCount;
        }
    }
}