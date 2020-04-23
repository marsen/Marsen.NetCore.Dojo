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
            if (GetLoggedUser() != null)
            {
                if (Enumerable.Contains(user.GetFriends(), GetLoggedUser()))
                {
                    return GetTripsList(user);
                    //tripList = GetTripsList(user);
                }

                return new List<Trip>();
            }
            else
            {
                throw new UserNotLoggedInException();
            }
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