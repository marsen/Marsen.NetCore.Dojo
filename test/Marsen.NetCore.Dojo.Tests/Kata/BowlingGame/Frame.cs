namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class Frame
    {
        public Frame(int? firstTry = null, int? secondTry = null)
        {
            if (firstTry + secondTry != 10)
            {
                Score = firstTry + secondTry;
            }
        }

        public int? Score { get; private set; }

        public void SetBonus(int bonus)
        {
            Score = 10 + bonus;
        }
    }
}