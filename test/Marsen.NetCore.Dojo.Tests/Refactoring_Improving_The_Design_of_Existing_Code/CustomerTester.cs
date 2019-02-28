using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Refactoring_Improving_The_Design_of_Existing_Code;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class CustomerTester
    {
        readonly Customer _customer = new Customer("Marsen");

        [Fact]
        public void no_items()
        {
            var actual = _customer.statement();
            var expected = "Rental Record for Marsen\nAmount owed is 0\nYou earned 0 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_new_release_one_day()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.NEW_RELEASE), 1));
            var actual = _customer.statement();
            var expected = "Rental Record for Marsen\n\tA\t3\nAmount owed is 3\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_new_release_2_day()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.NEW_RELEASE), 2));
            var actual = _customer.statement();
            var expected = "Rental Record for Marsen\n\tA\t6\nAmount owed is 6\nYou earned 2 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_regular_one_day()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.REGULAR), 1));
            var actual = _customer.statement();
            var expected = "Rental Record for Marsen\n\tA\t2\nAmount owed is 2\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_regular_3_day()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.REGULAR), 3));
            var actual = _customer.statement();
            var expected =
                "Rental Record for Marsen\n\tA\t3.5\nAmount owed is 3.5\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_childrens_one_day()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.CHILDRENS), 1));
            var actual = _customer.statement();
            var expected =
                "Rental Record for Marsen\n\tA\t1.5\nAmount owed is 1.5\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void rent_1_childrens_4_days()
        {
            _customer.addRental(new Rental(new Movie("A", Movie.CHILDRENS), 4));
            var actual = _customer.statement();
            var expected =
                "Rental Record for Marsen\n\tA\t3\nAmount owed is 3\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }
    }
}