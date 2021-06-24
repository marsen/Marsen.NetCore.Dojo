using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.FooBarQix
{
    public class FooBarQix
    {
        private readonly List<int> _ruleNumbers = new() { 3, 5, 7 };

        public string Get(int input)
        {
            var result = _ruleNumbers.Aggregate(string.Empty, (s, i) => new DivisibleRule(i).Apply(input, s));
            foreach (var c in input.ToString())
                result = _ruleNumbers.Aggregate(result, (s, i) => new ContainRule(i).Apply(c, s));

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }
    }
}