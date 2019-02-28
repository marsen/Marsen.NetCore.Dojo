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
                double thisAmount = 0;
                Rental each = (Rental) rentals.Current;
                //determine amounts for each line
                thisAmount = amountFor(each);

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE)
                    &&
                    each.getDaysRented() > 1) frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount +
                      "\n";
            result += "You earned " + frequentRenterPoints
                                    +
                                    " frequent renter points";
            return result;
        }

        private static double amountFor(Rental each)
        {
            double result = 0;
            switch (each.getMovie().getPriceCode())
            {
                case 0: //// Movie.REGULAR:
                    result += 2;
                    if (each.getDaysRented() > 2)

                        result += (each.getDaysRented() - 2) * 1.5;
                    break;
                case 1: //// Movie.NEW_RELEASE
                    result += each.getDaysRented() * 3;
                    break;
                case 2: //// Movie.CHILDRENS:
                    result += 1.5;
                    if (each.getDaysRented() > 3)
                        result += (each.getDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}