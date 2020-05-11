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
                result += "-" + input[i].ToString().ToUpper() + input[i].ToString().ToLower();
            }

            return result;
        }
    }
}