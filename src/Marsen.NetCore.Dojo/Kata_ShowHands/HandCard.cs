using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class HandCard
    {
        private readonly List<Card> _cardList;


        public HandCard(List<Card> parse)
        {
            this._cardList = parse;
            this.KeyCard = this.GetKeyCard();
        }


        public List<int> KeyCard { get; set; }

        public Category GetCategory()
        {
            var categoryRules = new List<ICategoryRule>
            {
                new Flush(),
                new FourOfAKind(),
                new Straight(),
                new ThreeOfAKind(),
                new TwoPair(),
                new OnePair(),
                new HighCard()
            };

            return categoryRules.First(x => x.Apply(this._cardList)).Category;
        }

        private List<int> GetKeyCard()
        {
            return this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().OrderBy(x => x.Count).Select(x => x.Rank)
                .ToList();
        }
    }
}