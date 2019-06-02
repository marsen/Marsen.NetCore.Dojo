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
            var result = _ruleNumbers.Aggregate(string.Empty, (s, i) => new DivisibleRule(i).Apply(input, s));
            foreach (var c in input.ToString().ToCharArray())
            {
                result = _ruleNumbers.Aggregate(result, (s, i) => new ContainRule(i).Apply(c, s));
                //ContainRule containRule = new ContainRule(3);
                //result = containRule.Apply(c, result);
                //containRule = new ContainRule(5);
                //result = containRule.Apply(c, result);
                //containRule = new ContainRule(7);
                //result = containRule.Apply(c, result);
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }
    }
}