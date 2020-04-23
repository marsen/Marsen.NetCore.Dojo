namespace Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public class ChildrenPrice : Price
    {
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