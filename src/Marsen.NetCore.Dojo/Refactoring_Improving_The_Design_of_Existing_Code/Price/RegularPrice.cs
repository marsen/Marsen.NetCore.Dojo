﻿namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.Price
{
    public class RegularPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.REGULAR;
        }
    }
}