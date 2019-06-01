using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        private readonly List<int> _ruleNumbers = new List<int> {3, 5, 7};

        public string Get(int input)
        {
            var result = string.Empty;
            foreach (var i in _ruleNumbers)
            {
                var rule = new DivisibleRule(i);
                result = rule.Apply(input, result);
            }

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


        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}