namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public class NewReleasePrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        public override double getCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int getFrequentRenterPoints(int daysRented)
        {
            return getPriceCode() == Movie.NEW_RELEASE &&
                   daysRented > 1
                ? 2
                : 1;
        }
    }
}