using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.Alphabet
{
    public class AlphabetGame
    {
        public string Generate(string input)
        {
            var chars = new List<char>();

            for (int i = 0 ;i < input.Length; i++)
            {
                chars.Add(Char.ToUpper(input[i]));
            }
            return string.Join('-', chars);
        }
    }
}