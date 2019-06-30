using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class ShowHand
    {
        private readonly string _firstPlayerName;

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            var cardParser = new CardParser();
            List<Card> firstCardList = cardParser.Parse(firstPlayerCard);
            var firstPlayerCategory = "Four Of a Kind";
            return $"{_firstPlayerName} Win, Because {firstPlayerCategory}";
        }
    }
}