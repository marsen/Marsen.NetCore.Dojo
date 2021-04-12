using System;
using System.Net.Http;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient = new() {BaseAddress = new Uri("http://joey.com/")};

        public bool IsLocked(string accountId)
        {
            //// check is locked
            var isLockedResponse =
                _httpClient.PostAsync("api/failedCounter/IsLocked", new StringContent(accountId)).Result;
            isLockedResponse.EnsureSuccessStatusCode();
            var isLocked = isLockedResponse.Content.ReadAsStringAsync().Result == "true";
            return isLocked;
        }

        public void ResetFailedCounter(string accountId)
        {
            //// reset failed counter
            var resetResponse = _httpClient.PostAsync("api/failedCounter/Reset", new StringContent(accountId))
                .Result;
            resetResponse.EnsureSuccessStatusCode();
        }

        public void AddFailedCounter(string accountId)
        {
            //// add failed counter
            var addFailedCountResponse =
                _httpClient.PostAsync("api/failedCounter/Add", new StringContent(accountId)).Result;
            addFailedCountResponse.EnsureSuccessStatusCode();
        }

        public string FailedCount(string accountId)
        {
            //// get failed counter
            var failedCountResponse =
                _httpClient.PostAsync("api/failedCounter/GetFailedCount", new StringContent(accountId)).Result;

            failedCountResponse.EnsureSuccessStatusCode();

            var failedCount = failedCountResponse.Content.ReadAsStringAsync().Result;
            return failedCount;
        }
    }
}