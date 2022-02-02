using System.Security.Cryptography;
using System.Text;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI
{
    public class Sha256Adapter : IHashAdapter
    {
        public string Hash(string password)
        {
            //// hash the password
            var sha256 = SHA256.Create();
            var hash = new StringBuilder();
            var crypto = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (var theByte in crypto) hash.Append(theByte.ToString("x2"));

            return hash.ToString();
        }
    }
}