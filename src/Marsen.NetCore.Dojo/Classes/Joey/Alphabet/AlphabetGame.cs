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

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    temp.Add(input.Substring(i, 1).ToUpper());
                }
                else
                {
                    string substring = string.Empty;
                    for (int j = 0; j < i; j++)
                    {
                        if (j == 0)
                        {
                            substring += input.Substring(i, 1).ToUpper();
                        }

                        substring += input.Substring(i, 1).ToLower();
                    }

                    temp.Add(substring);
                }
            }

            return string.Join('-', temp);
        }
    }
}