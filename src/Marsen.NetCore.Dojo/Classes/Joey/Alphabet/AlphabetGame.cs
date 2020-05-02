using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.Alphabet
{
    public class AlphabetGame
    {
        public string Generate(string input)
        {
            var temp = new List<string>();

            for (int i = 0 ;i < input.Length; i++)
            {
                temp.Add(input.Substring(i,1).ToUpper());
            }
            return string.Join('-', temp);
        }
    }
}