using Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class CustomerTester
    {
        private readonly Customer _customer = new("Marsen");

        [Fact]
        public void no_items()
        {
            var actual = _customer.Statement();
            var expected = "Rental Record for Marsen\nAmount owed is 0\nYou earned 0 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_new_release_one_day()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.NewRelease), 1));
            var actual = _customer.Statement();
            var expected = "Rental Record for Marsen\n\tA\t3\nAmount owed is 3\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_new_release_2_day()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.NewRelease), 2));
            var actual = _customer.Statement();
            var expected = "Rental Record for Marsen\n\tA\t6\nAmount owed is 6\nYou earned 2 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_regular_one_day()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.Regular), 1));
            var actual = _customer.Statement();
            var expected = "Rental Record for Marsen\n\tA\t2\nAmount owed is 2\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_regular_3_day()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.Regular), 3));
            var actual = _customer.Statement();
            var expected =
                "Rental Record for Marsen\n\tA\t3.5\nAmount owed is 3.5\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_children_one_day()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.Children), 1));
            var actual = _customer.Statement();
            var expected =
                "Rental Record for Marsen\n\tA\t1.5\nAmount owed is 1.5\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void rent_1_children_4_days()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.Children), 4));
            var actual = _customer.Statement();
            var expected =
                "Rental Record for Marsen\n\tA\t3\nAmount owed is 3\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void rent_1_children_3_days()
        {
            _customer.AddRental(new Rental(new Movie("A", MoveType.Children), 3));
            var actual = _customer.Statement();
            var expected =
                "Rental Record for Marsen\n\tA\t1.5\nAmount owed is 1.5\nYou earned 1 frequent renter points";
            Assert.Equal(expected, actual);
        }
    }
}