using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal
    {
        public string Do(string input)
        {
            return ByHalfLengthLoop(input);
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