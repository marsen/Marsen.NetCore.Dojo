using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            string result = "Rental Record for " + getName() + "\n";
            while (rentals.MoveNext())
            {
                Rental each = (Rental) rentals.Current;

                frequentRenterPoints = each.getFrequentRenterPoints();
                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" +
                          each.getCharge() + "\n";
                totalAmount += each.getCharge();
            }

            //add footer lines
            result += "Amount owed is " + getTotalAmount() +
                      "\n";
            result += "You earned " + frequentRenterPoints
                                    +
                                    " frequent renter points";
            return result;
        }

        private double getTotalAmount()
        {
            double result = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = (Rental) rentals.Current;
                result += each.getCharge();
            }

            return result;
        }
    }
}