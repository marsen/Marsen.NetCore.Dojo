using System;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            string result = string.Empty;


            result = CheckFizzRule(input, result);

            result = CheckBuzzRule(input, result);

            if (string.IsNullOrEmpty(result))
            {
                return input.ToString();
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