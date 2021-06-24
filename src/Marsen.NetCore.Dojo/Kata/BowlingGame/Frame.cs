namespace Marsen.NetCore.Dojo.Kata.BowlingGame
{
    public class Frame
    {
        private const string Strike = "Strike";
        private const string Spare = "Spare";
        private readonly string _bonusType;
        private readonly int? _firstTry;
        private readonly int? _secondTry;

        public Frame(int? firstTry = null, int? secondTry = null)
        {
            _firstTry = firstTry;
            _secondTry = secondTry;
            if (_firstTry == 10)
            {
                _secondTry = null;
                _bonusType = Strike;
            }
            else if (_firstTry + _secondTry == 10)
            {
                _bonusType = Spare;
            }
            else
            {
                Score = _firstTry + _secondTry;
            }
        }

        public int? Score { get; private set; }

        public void SetBonus(int spareBonus, int? strikeBonus)
        {
            switch (_bonusType)
            {
                case Spare:
                    Score = _firstTry + _secondTry + spareBonus;
                    break;
                case Strike:
                    Score = 10 + spareBonus + strikeBonus;
                    break;
            }
        }
    }
}