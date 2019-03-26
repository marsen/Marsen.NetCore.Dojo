using System;

namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            string result = string.Empty;

            var fizzRule = new FizzRule();
            result = fizzRule.Apply(input, result);
            var buzzRule = new BuzzRule();
            result = buzzRule.Apply(input, result);
            var normalRule = new NormalRule();
            result = normalRule.Apply(input, result);

            return result;
        }
    }
}