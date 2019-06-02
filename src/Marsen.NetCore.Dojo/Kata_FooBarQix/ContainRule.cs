using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class ContainRule
    {
        private readonly Dictionary<char, string> _charLookup = new Dictionary<char, string>()
        {
            {'3', "Foo"},
            {'5', "Bar"},
            {'7', "Qix"},
        };

        public string Apply(char c, string result)
        {
            if (c == '3')
            {
                result += _charLookup[c];
            }

            return result;
        }
    }
}