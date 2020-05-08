using System.Collections.Generic;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;

namespace Marsen.NetCore.Dojo.Tests.Books.Working_Effectively_with_Legacy_Code
{
    internal class StubTripService : TripService
    {
        private User _mockLoggedUser = new User();
        private List<Trip> _mockTripsList = new List<Trip>();

        public void SetLoggedUser(User user)
        {
            _mockLoggedUser = user;
        }

        public void SetTripsList(List<Trip> tripsList)
        {
            _mockTripsList = tripsList;
        }

        protected override User GetLoggedUser()
        {
            return _mockLoggedUser;
        }

        protected override List<Trip> GetTripsList(User user)
        {
            return _mockTripsList;
        }
    }
}