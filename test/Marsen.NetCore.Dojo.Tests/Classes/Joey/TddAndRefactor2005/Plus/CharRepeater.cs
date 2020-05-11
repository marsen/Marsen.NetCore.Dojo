using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            var result = string.Empty;
            for (var i = 0; i < input.Length; i++)
            {
                result += input[i].ToString().ToUpper();
            }

            return result;
        }
    }
}