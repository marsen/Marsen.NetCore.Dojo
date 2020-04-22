namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}