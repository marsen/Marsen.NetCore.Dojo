using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        private readonly List<IRule> _rules = new List<IRule> {new FizzRule(), new BuzzRule(), new NormalRule()};

        public string Get(int input)
        {
            string result = string.Empty;
            return _rules.Aggregate(result, (s, r) => r.Apply(input, s));
        }
    }
}