using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.GuessNumber
{
    public class RandomHelper : IRandomInt
    {
        public string GetNonRepeatInt(int length)
        {
            return new string("1234567890"
                .OrderBy(x => new Random().Next())
                .Take(length)
                .ToArray());
        }
    }
}