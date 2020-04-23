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
            List<Trip> tripList = new List<Trip>();
            var loggedUser = GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                if (Enumerable.Contains(user.GetFriends(), loggedUser))
                {
                    isFriend = true;
                }

                if (isFriend)
                {
                    tripList = TripDao.FindTripsByUser(user);
                }

                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}