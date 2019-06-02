using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        private readonly List<int> _ruleNumbers = new List<int> {3, 5, 7};

        private readonly Dictionary<char, string> _charLookup = new Dictionary<char, string>()
        {
            {'3', "Foo"},
            {'5', "Bar"},
            {'7', "Qix"},
        };

        public string Get(int input)
        {
            var result = _ruleNumbers.Aggregate(string.Empty, (s, i) => new DivisibleRule(i).Apply(input, s));
            foreach (var c in input.ToString().ToCharArray())
            {
                result = ContainCharRule(c, result);

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

        private string ContainCharRule(char c, string result)
        {
            if (c == '3')
            {
                result += _charLookup[c];
            }

            return result;
        }
    }
}