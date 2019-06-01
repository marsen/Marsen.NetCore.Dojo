using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            var result = string.Empty;
            result = ApplyDivisible3Rule(input, result);

            result = ApplyDivisible5Rule(input, result);

            result = ApplyDivisible7Rule(input, result);

            foreach (var c in input.ToString().ToCharArray())
            {
                if (c == '3')
                {
                    result += "Foo";
                }

                if (c == '5')
                {
                    result += "Bar";
                }

                if (c == '7')
                {
                    result += "Qix";
                }
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }

        private string ApplyDivisible7Rule(int input, string result)
        {
            if (IsDivisibleBy(7, input))
            {
                result += "Qix";
            }

            return result;
        }

        private string ApplyDivisible5Rule(int input, string result)
        {
            if (IsDivisibleBy(5, input))
            {
                result += "Bar";
            }

            return result;
        }

        private string ApplyDivisible3Rule(int input, string result)
        {
            if (IsDivisibleBy(3, input))
            {
                result += "Foo";
            }

            return result;
        }

        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}