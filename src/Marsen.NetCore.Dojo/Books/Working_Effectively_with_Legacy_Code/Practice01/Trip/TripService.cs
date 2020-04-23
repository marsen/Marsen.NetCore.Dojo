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
            if (GetLoggedUser() != null)
            {
                if (Enumerable.Contains(user.GetFriends(), GetLoggedUser()))
                {
                    tripList = GetTripsList(user);
                }

                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }

        private static List<Trip> GetTripsList(User user)
        {
            return TripDao.FindTripsByUser(user);
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}