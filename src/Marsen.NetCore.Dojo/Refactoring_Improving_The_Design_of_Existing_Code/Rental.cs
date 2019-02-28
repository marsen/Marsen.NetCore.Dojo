using System;
using System.Collections.Generic;
using System.Text;

namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            return GetMovie().GetCharge(GetDaysRented());
        }

        public int GetFrequentRenterPoints()
        {
            // add bonus for a two day new release rental
            return GetMovie().GetFrequentRenterPoints(GetDaysRented());
        }
    }
}