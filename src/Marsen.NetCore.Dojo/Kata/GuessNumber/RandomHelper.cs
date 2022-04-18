using System.Linq;
using Marsen.NetCore.Dojo.Extend;

namespace Marsen.NetCore.Dojo.Kata.GuessNumber;

public class RandomHelper : IRandomInt
{
    public string GetNonRepeatInt(int length)
    {
        return new string("1234567890"
            .Shuffle()
            .Take(4)
            .ToArray());
    }
}