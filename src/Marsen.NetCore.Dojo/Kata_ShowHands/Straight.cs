using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class Straight : ICategoryRule
    {
        private const string AllCard = "1,2,3,4,5,6,7,8,9,10,11,12,13,14";


        public bool Apply(List<Card> cardList)
        {
            var orderedRank = string.Join(',', cardList.OrderBy(x => x.Rank).Select(x => x.Rank));
            return AllCard.Contains(orderedRank) || orderedRank == "2,3,4,5,14";
        }

        public Category Category => Category.Straight;
    }
}