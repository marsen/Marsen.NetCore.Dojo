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
            if (BonusCount > 0)
                _score = 10 + bonus + secondTry;
        }

        public void Spare()
        {
            BonusCount = 1;
        }

        public int BonusCount { get; private set; }

        public void Strike()
        {
            BonusCount = 2;
        }
    }
}