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

            IRule fizzRule = new FizzRule();
            result = fizzRule.Apply(input, result);
            IRule buzzRule = new BuzzRule();
            result = buzzRule.Apply(input, result);
            IRule normalRule = new NormalRule();
            result = normalRule.Apply(input, result);

            return result;
        }
    }
}