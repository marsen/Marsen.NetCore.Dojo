using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.Alphabet
{
    public class AlphabetGame
    {
        public string Generate(string input)
        {
            var chars = new List<char>
            {
                'A'
            };
            
            return string.Join('-', chars);
        }
    }
}