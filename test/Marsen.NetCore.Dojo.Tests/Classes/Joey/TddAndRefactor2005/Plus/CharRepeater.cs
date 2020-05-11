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
                var substring = input.Substring(i, 1);
                var lower = RepeatLower(substring,i);
                result += "-" + substring.ToUpper() + lower;
                // if (i > 1)
                // {
                //     var lower = RepeatLower(substring,i);
                //     result += "-" + substring.ToUpper() + lower;
                // }
                // else
                // {
                //     var lower = RepeatLower(substring,i);
                //     result += "-" + substring.ToUpper() + lower;
                // }
            }

            return result;
        }

        private static string RepeatLower(string substring,int times)
        {
            string result = string.Empty;
            for (int i = 0; i < times; i++)
            {
                result += substring.ToLower();
            }

            return result;
            var lower = substring.ToLower() + substring.ToLower();
            return lower;
        }
    }
}