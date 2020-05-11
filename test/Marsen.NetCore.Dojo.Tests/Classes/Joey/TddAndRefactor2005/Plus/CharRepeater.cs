using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            var list = new List<string>();
            list.Add(input.Substring(0,1).ToUpper());
            for (var i = 1; i < input.Length; i++)
            {
                var lower = RepeatLower(input.Substring(i, 1),i);
                list.Add(input.Substring(i, 1).ToUpper()+lower);
            }

            return string.Join('-', list);
        }

        private string RepeatLower(string substring,int times)
        {
            var result = string.Empty;
            for (var i = 0; i < times; i++)
            {
                result += substring.ToLower();
            }

            return result;
        }
    }
}