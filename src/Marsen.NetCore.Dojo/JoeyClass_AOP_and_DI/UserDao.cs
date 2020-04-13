using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class UserDao
    {
        public string PasswordFromDb(string accountId)
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
}