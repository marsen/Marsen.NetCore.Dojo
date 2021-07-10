using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class Game
    {
        private string _answer;

        public string Guess(string number)
        {
            SetAnswer();
            int aCounter = 0;
            int bCounter = 0;
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
            //TODO Random Answer
            //TODO Hard Code Answer 1234
            _answer = "1234";
        }

        //TODO Control Random Answer
        public string RandomAnswer()
        {
            return new string("1234567890"
                .OrderBy(x => new Random().Next())
                .Take(4)
                .ToArray());
        }
    }
}