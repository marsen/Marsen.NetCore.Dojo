using FluentAssertions;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;
using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.Working_Effectively_with_Legacy_Code
{
    public class TripServiceTests
    {
        private readonly StubTripService _target;
        private User UserAmy = new StubUser();
        private User UserBob = new User();
        private User UserCarter = new User();

        public TripServiceTests()
        {
            _target = new StubTripService();
        }

        [Fact]
        public void NotLoginThrowException()
        {
            GiveLoggedUser(null);
            Action act = () => _target.GetTripsByUser(UserAmy);
            act.Should().Throw<UserNotLoggedInException>();
        }

        [Fact]
        public void UserWithoutFriendsReturnEmptyList()
        {
            GiveUserFriends(new List<User>());
            GiveLoggedUser(UserBob);
            var actual = _target.GetTripsByUser(UserAmy);
            actual.Should().BeNullOrEmpty();
        }

        [Fact]
        public void UserFriendsNotIncludedLoggedUser()
        {
            GiveUserFriends(new List<User> {UserCarter});
            GiveLoggedUser(UserBob);
            var actual = _target.GetTripsByUser(UserAmy);
            actual.Should().BeNullOrEmpty();
        }

        [Fact]
        public void UserFriendsIncludedLoggedUser()
        {
            GiveUserFriends(new List<User> {UserBob, UserCarter});
            GiveLoggedUser(UserBob);
            var expected = new List<Trip> {new Trip()};
            GiveTripsList(expected);
            var actual = _target.GetTripsByUser(UserAmy);
            actual.Should().BeEquivalentTo(expected);
        }

        private void GiveTripsList(List<Trip> tripsList)
        {
            _target.SetTripsList(tripsList);
        }

        private void GiveLoggedUser(User user)
        {
            _target.SetLoggedUser(user);
        }

        private void GiveUserFriends(List<User> friends)
        {
            ((StubUser) UserAmy).SetFriends(friends);
        }
    }

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

    internal class StubUser : User
    {
        private List<User> _mockFriendsList;

        public override List<User> GetFriends()
        {
            return _mockFriendsList;
        }

        public void SetFriends(List<User> friends)
        {
            this._mockFriendsList = friends;
        }
    }
}