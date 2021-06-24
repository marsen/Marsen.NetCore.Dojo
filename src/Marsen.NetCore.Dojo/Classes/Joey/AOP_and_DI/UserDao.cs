using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI
{
    public class UserDao : IUserDao
    {
        public string PasswordFromDb(string accountId)
        {
            //// get the password from database
            using var connection = new SqlConnection("my connection string");
            var passwordFromDb = connection
                .Query<string>("spGetUserPassword", new { Id = accountId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();

            return passwordFromDb;
        }
    }
}