namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public abstract class Price
    {
        public abstract int getPriceCode();

        public double getCharge(int getDaysRented)
        {
            double result = 0;
            switch (getPriceCode())
            {
                case 0: //// Movie.REGULAR:
                    result += 2;
                    if (getDaysRented > 2)

                        result += (getDaysRented - 2) * 1.5;
                    break;
                case 1: //// Movie.NEW_RELEASE
                    result += getDaysRented * 3;
                    break;
                case 2: //// Movie.CHILDRENS:
                    result += 1.5;
                    if (getDaysRented > 3)
                        result += (getDaysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}