using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal
    {
        public string Do(string input)
        {
            if (input is null)
            {
                return input;
            }

            var cArray = input.ToCharArray();
            for (int i = 0; i < cArray.Length / 2; i++)
            {
                var temp = cArray[i];
                cArray[i] = cArray[cArray.Length - 1 - i];
                cArray[cArray.Length - 1 - i] = temp;
            }

            return new string(cArray);
        }

        private string ByLambda(string input)
        {
            return input?.ToCharArray().Aggregate(string.Empty, (current, c) => c + current);
        }
    }
}