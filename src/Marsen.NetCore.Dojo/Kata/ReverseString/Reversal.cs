using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal : IStringReversal
    {
        public string Do(string input)
        {
            return input is null ? null : new string(input.Reverse().ToArray());
        }
    }
}