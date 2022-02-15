using System.Collections.Generic;
using System.Text;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.Plus
{
    public class AlphabetGame
    {
        public string Generate(string input)
        {
            var temp = new List<string>();

            for (var i = 0; i < input.Length; i++)
                if (i == 0)
                {
                    temp.Add(input.Substring(i, 1).ToUpper());
                }
                else
                {
                    var sb = new StringBuilder();
                    for (var j = 0; j < i; j++)
                    {
                        if (j == 0) sb.Append(input.Substring(i, 1).ToUpper());

                        sb.Append(input.Substring(i, 1).ToLower());
                    }

                    temp.Add(sb.ToString());
                }

            return string.Join('-', temp);
        }
    }
}