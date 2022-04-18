namespace Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code.PriceState;

public class NewReleasePrice : Price
{
    public override double GetCharge(int daysRented)
    {
        return daysRented * 3;
    }

    public override int GetFrequentRenterPoints(int daysRented)
    {
        return daysRented > 1 ? 2 : 1;
    }
}