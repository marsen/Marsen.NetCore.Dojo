using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ReverseString;

public class LoopReversal : IStringReversal
{
    public string Do(string input)
    {
        return input?.ToCharArray().Aggregate(string.Empty, (current, c) => c + current);
    }
}