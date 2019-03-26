using System;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            string result = string.Empty;

            var fizzRule = new FizzRule();
            result = fizzRule.Apply(input, result);

            result = CheckBuzzRule(input, result);

            result = CheckNormalRule(input, result);

            return result;
        }

        private string CheckNormalRule(int input, string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                result = input.ToString();
            }

            return result;
        }

        private string CheckBuzzRule(int input, string result)
        {
            if (input % 5 == 0)
            {
                result += "Buzz";
            }

            return result;
        }

        private string CheckFizzRule(int input, string result)
        {
            if (input % 3 == 0)
            {
                result += "Fizz";
            }

            return result;
        }
    }
}