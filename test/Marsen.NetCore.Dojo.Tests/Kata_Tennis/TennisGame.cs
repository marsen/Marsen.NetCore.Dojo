namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGame
    {
        private int _firstPlayerScore;

        public string Score()
        {
            if (_firstPlayerScore == 1)
            {
                return "Fifteen Love";
            }

            if (_firstPlayerScore == 2)
            {
                return "Thirty Love";
            }

            return "Love All";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScore++;
        }
    }
}