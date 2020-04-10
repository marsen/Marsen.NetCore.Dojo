using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService
    {
        public bool Verify(string accountId, string password, string otp)
        {
            string passwordFromDb = string.Empty;
            //using (var connection = new SqlConnection("my connection string"))
            //{
            //    passwordFromDb = connection.Query<string>("spGetUserPassword", new {Id = accountId},
            //        commandType: CommandType.StoredProcedure).SingleOrDefault();
            //}

            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            var hashedPassword = hash.ToString();

            var httpClient = new HttpClient() {BaseAddress = new Uri("http://joey.com/")};
            var response = httpClient.PostAsync("api/otps", new StringContent(accountId)).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"web api error, accountId:{accountId}");
            }

            var currentOtp = response.Content.ReadAsStringAsync().Result;

            if (passwordFromDb == hashedPassword && currentOtp == otp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}