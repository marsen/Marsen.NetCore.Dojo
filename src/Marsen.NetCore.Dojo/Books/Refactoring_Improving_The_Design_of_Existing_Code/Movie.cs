using Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code.PriceState;

namespace Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code
{
    public class Movie
    {
        private readonly string _title;
        private Price _price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie" /> class.
        /// </summary>
        public Movie(string title, MoveType moveType)
        {
            _title = title;
            SetPriceCode(moveType);
        }

        public void SetPriceCode(MoveType arg)
        {
            switch (arg)
            {
                case MoveType.Regular: //// Movie.REGULAR
                    _price = new RegularPrice();
                    break;

                case MoveType.NewRelease: //// Movie.NEW_RELEASE
                    _price = new NewReleasePrice();
                    break;

                case MoveType.Children: //// Movie.CHILDRENS:
                    _price = new ChildrenPrice();
                    break;
            }
        }

        public string GetTitle()
        {
            return _title;
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}