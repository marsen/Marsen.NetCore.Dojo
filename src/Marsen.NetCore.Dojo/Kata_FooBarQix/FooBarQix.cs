using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            var result = string.Empty;
            if (IsDivisibleBy(3, input))
            {
                result = AppendFoo(result);
            }

            if (IsDivisibleBy(5, input))
            {
                result = AppendBar(result);
            }

            if (IsDivisibleBy(7, input))
            {
                result = AppendQix(result);
            }

            foreach (var c in input.ToString().ToCharArray())
            {
                if (c == '3')
                {
                    result = AppendFoo(result);
                }

                if (c == '5')
                {
                    result = AppendBar(result);
                }

                if (c == '7')
                {
                    result = AppendQix(result);
                }
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }

        private static string AppendQix(string result)
        {
            result += "Qix";
            return result;
        }

        private static string AppendBar(string result)
        {
            result += "Bar";
            return result;
        }

        private static string AppendFoo(string result)
        {
            result += "Foo";
            return result;
        }

        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}