using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.GuessNumber
{
    public class RandomNumber : IRandomInt
    {
        public string Get(int length)
        {
            return new string("1234567890"
                .OrderBy(x => new Random().Next())
                .Take(length)
                .ToArray());
        }
    }
}