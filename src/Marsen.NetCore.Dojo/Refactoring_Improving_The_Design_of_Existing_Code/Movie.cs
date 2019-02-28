using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code.PriceState;

namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Movie
    {
        public static readonly int CHILDRENS = 2;
        public static readonly int REGULAR = 0;
        public static readonly int NEW_RELEASE = 1;
        private string _title;
        private int _priceCode;
        private Price _price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie" /> class.
        /// </summary>
        public Movie(string title, int priceCode)
        {
            _title = title;
            setPriceCode(priceCode);
        }

        public int getPriceCode()
        {
            return _price.getPriceCode();
        }

        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                case 0: //// Movie.REGULAR
                    _price = new RegularPrice();
                    break;

                case 1: //// Movie.NEW_RELEASE
                    _price = new NewReleasePrice();
                    break;

                case 2: //// Movie.CHILDRENS:
                    _price = new ChildrenPrice();
                    break;
            }
        }

        public string getTitle()
        {
            return _title;
        }

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

        public int getFrequentRenterPoints(int getDaysRented)
        {
            return getPriceCode() == Movie.NEW_RELEASE &&
                   getDaysRented > 1
                ? 2
                : 1;
        }
    }
}