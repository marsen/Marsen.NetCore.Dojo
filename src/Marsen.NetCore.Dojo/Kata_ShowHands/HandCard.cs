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
        }


        public List<int> KeyCard { get; set; }

        public Category GetCategory()
        {
            this.KeyCard = this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().OrderBy(x => x.Count).Select(x => x.Rank)
                .ToList();
            List<ICategoryRule> categoryRules = new List<ICategoryRule>
            {
                new Flush(),
                new FourOfAKind(),
                new Straight(),
                new ThreeOfAKind(),
                new TwoPair(),
                new OnePair(),
                new HighCard()
            };

            return categoryRules.FirstOrDefault(x => x.Apply(this._cardList)).Category;

            if (new Flush().Apply(this._cardList))
            {
                return Category.Flush;
            }

            if (new FourOfAKind().Apply(this._cardList))
            {
                return Category.FourOfAKind;
            }

            if (new Straight().Apply(this._cardList))
            {
                return Category.Straight;
            }

            if (new ThreeOfAKind().Apply(this._cardList))
            {
                return Category.ThreeOfAKind;
            }

            if (new TwoPair().Apply(this._cardList))
            {
                return Category.TwoPair;
            }

            if (new OnePair().Apply(this._cardList))
            {
                return Category.OnePair;
            }

            return Category.HighCard;
        }
    }

    public class HighCard : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return true;
        }

        public Category Category => Category.HighCard;
    }

    public class OnePair : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                       .GroupBy(x => x.Rank)
                       .Select(g => new {Count = g.Count(), Rank = g.Key}).Count(x => x.Count == 2) == 1;
        }

        public Category Category => Category.OnePair;
    }

    public class TwoPair : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                       .GroupBy(x => x.Rank)
                       .Select(g => new {Count = g.Count(), Rank = g.Key}).Count(x => x.Count == 2) == 2;
        }

        public Category Category => Category.TwoPair;
    }

    public class ThreeOfAKind : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().Any(x => x.Count == 3);
        }

        public Category Category => Category.ThreeOfAKind;
    }

    public class Straight : ICategoryRule
    {
        private const string allCard = "1,2,3,4,5,6,7,8,9,10,J,Q,K";


        public bool Apply(List<Card> cardList)
        {
            return allCard.Contains(string.Join(',', cardList.OrderBy(x => x.Rank).Select(x => x.Rank)));
        }

        public Category Category => Category.Straight;
    }
}