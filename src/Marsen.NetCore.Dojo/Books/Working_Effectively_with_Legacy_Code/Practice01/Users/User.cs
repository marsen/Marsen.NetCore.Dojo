using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users
{
    public class User
    {
        private readonly List<Trip.Trip> _trips = new List<Trip.Trip>();
        private readonly List<User> _friends = new List<User>();

        public virtual List<User> GetFriends()
        {
            return _friends;
        }

        public void AddFriend(User user)
        {
            _friends.Add(user);
        }

        public void AddTrip(Trip.Trip trip)
        {
            _trips.Add(trip);
        }

        public List<Trip.Trip> Trips()
        {
            return _trips;
        }
    }
}