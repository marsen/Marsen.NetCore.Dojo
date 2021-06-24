namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class Frame
    {
        private readonly int? _firstTry;
        private readonly int? _secondTry;
        private int? _score;

        public Frame(int? firstTry = null, int? secondTry = null)
        {
            _firstTry = firstTry;
            _secondTry = secondTry;
            if (_firstTry + _secondTry != 10)
            {
                _score = _firstTry + _secondTry;
            }
        }

        public int? Score
        {
            get { return _score; }
        }

        public void SetBonus(int bonus, int? secondTry)
        {
            _score = _firstTry + _secondTry + bonus;
            BonusCount--;
        }

        public void Spare()
        {
            BonusCount = 1;
        }

        public int BonusCount { get; private set; }

    }
}