using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            var list = input.Select((t, i) => t.ToString().ToUpper() + Repeat(t.ToString(), i).ToLower()).ToList();

            return string.Join('-', list);
        }

        private string Repeat(string substring, int times)
        {
            var result = string.Empty;
            for (var i = 0; i < times; i++)
            {
                result += substring;
            }

            return result;
        }
    }
}