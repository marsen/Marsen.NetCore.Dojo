﻿namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState
{
    public abstract class Price
    {
        public abstract int getPriceCode();

        public abstract double getCharge(int daysRented);

        public int getFrequentRenterPoints(int daysRented)
        {
            return getPriceCode() == Movie.NEW_RELEASE &&
                   daysRented > 1
                ? 2
                : 1;
        }
    }
}