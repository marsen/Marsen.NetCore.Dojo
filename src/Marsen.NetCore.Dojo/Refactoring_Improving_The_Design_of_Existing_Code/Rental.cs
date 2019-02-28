using System;
using System.Collections.Generic;
using System.Text;

namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public Movie getMovie()
        {
            return _movie;
        }

        public double getCharge()
        {
            double result = 0;
            switch (getMovie().getPriceCode())
            {
                case 0: //// Movie.REGULAR:
                    result += 2;
                    if (getDaysRented() > 2)

                        result += (getDaysRented() - 2) * 1.5;
                    break;
                case 1: //// Movie.NEW_RELEASE
                    result += getDaysRented() * 3;
                    break;
                case 2: //// Movie.CHILDRENS:
                    result += 1.5;
                    if (getDaysRented() > 3)
                        result += (getDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }

        public int getFrequentRenterPoints()
        {
            // add bonus for a two day new release rental
            return getMovie().getPriceCode() == Movie.NEW_RELEASE &&
                   getDaysRented() > 1
                ? 2
                : 1;
        }
    }
}