using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            return IsLogin() ? GetUserTripsList(user) : throw new UserNotLoggedInException();
        }

        private bool IsLogin()
        {
            return GetLoggedUser() != null;
        }

        private List<Trip> GetUserTripsList(User user)
        {
            return IsUserFriendsContainsLoggedUser(user) ? GetTripsList(user) : new List<Trip>();
        }

        private bool IsUserFriendsContainsLoggedUser(User user)
        {
            return Enumerable.Contains(user.GetFriends(), GetLoggedUser());
        }

        protected virtual List<Trip> GetTripsList(User user)
        {
            return TripDao.FindTripsByUser(user);
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}