using System;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            string result = string.Empty;
            if (input % 15 == 0)
            {
                return "FizzBuzz";
            }

            if (input == 5)
            {
                return "Buzz";
            }

            if (input % 3 == 0)
            {
                return "Fizz";
            }

            if (string.IsNullOrEmpty(result))
            {
                return input.ToString();
            }

            return result;
            return input.ToString();
        }
    }
}