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

            var result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                var c = input.Substring(i, 1);
                result = c + result;
            }

            foreach (var c in input.ToCharArray())
            {
                //result = c + result;
            }

            return result;
        }

        private string ByLambda(string input)
        {
            return input?.ToCharArray().Aggregate(string.Empty, (current, c) => c + current);
        }
    }
}