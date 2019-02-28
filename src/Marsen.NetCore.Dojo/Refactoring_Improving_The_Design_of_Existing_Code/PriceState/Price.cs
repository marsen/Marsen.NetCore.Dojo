namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public abstract class Price
    {
        public abstract int getPriceCode();

        public double getCharge(int daysRented)
        {
            double result = 0;
            switch (getPriceCode())
            {
                case 0: //// Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)

                        result += (daysRented - 2) * 1.5;
                    break;
                case 1: //// Movie.NEW_RELEASE
                    result += daysRented * 3;
                    break;
                case 2: //// Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}