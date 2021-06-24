namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class Frame
    {
        private readonly int? _firstTry;
        private readonly int? _secondTry;

        public Frame(int? firstTry = null, int? secondTry = null)
        {
            _firstTry = firstTry;
            _secondTry = secondTry;
            if (_firstTry + _secondTry != 10) Score = _firstTry + _secondTry;
        }

        public int? Score { get; private set; }

        private string BonusType { get; set; }

        public void SetBonus(int spareBonus, int? strikeBonus)
        {
            Score = BonusType switch
            {
                "Spare" => _firstTry + _secondTry + spareBonus,
                "Strike" => 10 + spareBonus + strikeBonus,
                _ => Score
            };
        }

        public void Spare()
        {
            BonusType = "Spare";
        }

        public void Strike()
        {
            BonusType = "Strike";
        }
    }
}