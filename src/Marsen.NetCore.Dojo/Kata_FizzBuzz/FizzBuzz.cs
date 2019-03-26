using System;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
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