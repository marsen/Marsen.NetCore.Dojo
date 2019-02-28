namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public class ChildrenPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 0;
            result += 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}