namespace Marsen.NetCore.Dojo.Kata.GuessNumber
{
    public class Game
    {
        private readonly IRandomInt _randomInt;
        private string _answer;

        public Game(IRandomInt randomInt)
        {
            _randomInt = randomInt;
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
            _answer = _randomInt.GetNonRepeatInt(4);
        }
    }
}