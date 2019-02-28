namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 0;
            result += 2;
            if (daysRented > 2)

                result += (daysRented - 2) * 1.5;
            return result;
        }
    }
}