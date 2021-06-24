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

        public void SetBonus(int spareBonus, int? strikeBonus)
        {
            if (BonusType == "Spare")
            {
                _score = _firstTry + _secondTry + spareBonus;
                BonusCount--;
            }

            if (BonusType=="Strike")
            {
                _score = 10 + spareBonus + strikeBonus;
                BonusCount--;
            }
        }

        public void Spare()
        {
            BonusType = "Spare";
            BonusCount = 1;
        }

        private string BonusType { get; set; }

        public int BonusCount { get; private set; }

        public void Strike()
        {
            BonusType = "Strike";
            BonusCount = 2;
        }
    }
}