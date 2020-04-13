using System.Text;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class HashAdapter
    {
        public string HashedPassword(string password)
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
    }
}