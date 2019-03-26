using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            List<IRule> rules = new List<IRule> {new FizzRule(), new BuzzRule(), new NormalRule()};
            string result = string.Empty;
            return rules.Aggregate(result, (s, r) => r.Apply(input, s));

            rules.ForEach(rule => result = rule.Apply(input, result));
            return result;
        }
    }
}