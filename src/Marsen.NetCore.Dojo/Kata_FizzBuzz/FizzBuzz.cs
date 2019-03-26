using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            List<IRule> rules = new List<IRule> {new FizzRule(), new BuzzRule(), new NormalRule()};
            string result = string.Empty;
            rules.ForEach(rule => result = rule.Apply(input, result));
            return result;
        }
    }
}