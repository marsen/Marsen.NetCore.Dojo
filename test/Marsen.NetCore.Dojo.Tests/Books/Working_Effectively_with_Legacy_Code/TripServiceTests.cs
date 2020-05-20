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
        private readonly User _userAmy = new StubUser();
        private readonly User _userBob = new User();
        private readonly User _userCarter = new User();

        public TripServiceTests()
        {
            _target = new StubTripService();
        }

        [Fact]
        public void NotLoginThrowException()
        {
            GiveLoggedUser(null);
            Action act = () => _target.GetTripsByUser(_userAmy);
            act.Should().Throw<UserNotLoggedInException>();
        }

        [Fact]
        public void UserWithoutFriendsReturnEmptyList()
        {
            GiveUserFriends(new List<User>());
            GiveLoggedUser(_userBob);
            var actual = _target.GetTripsByUser(_userAmy);
            actual.Should().BeNullOrEmpty();
        }

        [Fact]
        public void UserFriendsNotIncludedLoggedUser()
        {
            GiveUserFriends(new List<User> {_userCarter});
            GiveLoggedUser(_userBob);
            var actual = _target.GetTripsByUser(_userAmy);
            actual.Should().BeNullOrEmpty();
        }

        [Fact]
        public void UserFriendsIncludedLoggedUser()
        {
            GiveUserFriends(new List<User> {_userBob, _userCarter});
            GiveLoggedUser(_userBob);
            var expected = new List<Trip> {new Trip()};
            GiveTripsList(expected);
            var actual = _target.GetTripsByUser(_userAmy);
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
            ((StubUser) _userAmy).SetFriends(friends);
        }
    }
}