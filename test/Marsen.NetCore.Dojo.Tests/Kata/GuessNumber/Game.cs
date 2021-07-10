using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class Game
    {
        private readonly IHelper _helper;
        private string _answer;

        public Game(IHelper helper)
        {
            _helper = helper;
        }

        public string Guess(string number)
        {
            SetAnswer();
            var aCounter = 0;
            var bCounter = 0;
            for (var i = 0; i < _answer.Length; i++)
            {
                if (_answer[i] == number[i])
                {
                    aCounter++;
                    continue;
                }

                if (_answer.Contains(number[i]))
                {
                    bCounter++;
                }
            }

            return $"{aCounter}A{bCounter}B";
        }

        private void SetAnswer()
        {
            _answer = _helper.Get(4);
        }
    }

    public interface IHelper
    {
        //TODO rename
        string Get(int count);
    }

    public class RandomNumber : IHelper
    {
        //TODO rename
        public string Get(int count)
        {
            return new string("1234567890"
                .OrderBy(x => new Random().Next())
                .Take(count)
                .ToArray());
        }
    }
}