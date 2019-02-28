using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            IEnumerator rentals = _rentals.GetEnumerator();
            string result = "Rental Record for " + GetName() + "\n";
            while (rentals.MoveNext())
            {
                Rental each = (Rental) rentals.Current;

                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                          each.GetCharge() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + GetFrequentRenterPoints() + " frequent renter points";
            return result;
        }

        private double GetTotalAmount()
        {
            double result = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = (Rental) rentals.Current;
                result += each.GetCharge();
            }

            return result;
        }

        private int GetFrequentRenterPoints()
        {
            int result = 0;

            IEnumerator rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = (Rental) rentals.Current;
                result += each.GetFrequentRenterPoints();
            }

            return result;
        }
    }
}