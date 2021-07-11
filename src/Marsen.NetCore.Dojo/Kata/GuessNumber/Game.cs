namespace Marsen.NetCore.Dojo.Kata.GuessNumber
{
    public class Game
    {
        private readonly string _answer;

        public Game(IRandomInt randomInt)
        {
            _answer = randomInt.GetNonRepeatInt(4);
        }

        public string Guess(string number)
        {
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
    }
}