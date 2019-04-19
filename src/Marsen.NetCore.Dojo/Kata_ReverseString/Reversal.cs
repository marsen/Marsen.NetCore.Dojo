using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal
    {
        public string Do(string input)
        {
            return ByRecursion(input);
        }

        private string ByRecursion(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return input;
            }

            var s1 = input.Substring(0, 1);
            var s2 = input.Substring(1);
            return ByRecursion(s2) + s1;
        }

        private static string ByHalfLengthLoop(string input)
        {
            if (input is null)
            {
                return null;
            }

            var cArray = input.ToCharArray();
            for (var i = 0; i < cArray.Length / 2; i++)
            {
                var temp = cArray[i];
                var l = cArray.Length - 1 - i;
                cArray[i] = cArray[l];
                cArray[l] = temp;
            }

            return new string(cArray);
        }

        private string ByLambda(string input)
        {
            return input?.ToCharArray().Aggregate(string.Empty, (current, c) => c + current);
        }
    }
}