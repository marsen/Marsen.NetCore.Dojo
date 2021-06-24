namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
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
                _bonusType = Spare;
            else
                Score = _firstTry + _secondTry;
        }

        public int? Score { get; private set; }

        public void SetBonus(int spareBonus, int? strikeBonus)
        {
            Score = _bonusType switch
            {
                Spare => _firstTry + _secondTry + spareBonus,
                Strike => 10 + spareBonus + strikeBonus,
                _ => Score
            };
        }
    }
}