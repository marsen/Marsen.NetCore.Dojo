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
            var result = input.Substring(0,1).ToUpper();
            list.Add(input.Substring(0,1).ToUpper());
            for (var i = 1; i < input.Length; i++)
            {
                var substring = input.Substring(i, 1);
                var lower = RepeatLower(substring,i);
                list.Add(substring.ToUpper()+lower);
                result += "-" + substring.ToUpper() + lower;
            }

            return string.Join('-', list);
            return result;
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