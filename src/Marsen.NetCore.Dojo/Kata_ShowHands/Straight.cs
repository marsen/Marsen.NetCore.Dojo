using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
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