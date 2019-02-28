namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public class ChildrenPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.CHILDRENS;
        }
    }
}