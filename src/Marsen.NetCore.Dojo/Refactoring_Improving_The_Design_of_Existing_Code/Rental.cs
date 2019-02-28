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
            return getMovie().getCharge(getDaysRented());
        }

        public int getFrequentRenterPoints()
        {
            return getMovie().getFrequentRenterPoints(getDaysRented());
            // add bonus for a two day new release rental
            return getMovie().getPriceCode() == Movie.NEW_RELEASE &&
                   getDaysRented() > 1
                ? 2
                : 1;
        }
    }
}