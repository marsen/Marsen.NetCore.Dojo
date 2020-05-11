using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            var result = input[0].ToString().ToUpper();
            for (var i = 1; i < input.Length; i++)
            {
                var substring = input.Substring(i,1);
                result += "-" + substring.ToUpper() + substring.ToLower();
            }

            return result;
        }
    }
}