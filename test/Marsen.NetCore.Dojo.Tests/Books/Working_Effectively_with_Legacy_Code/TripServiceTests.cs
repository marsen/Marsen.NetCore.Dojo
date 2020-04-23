using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.Working_Effectively_with_Legacy_Code
{
    public class TripServiceTests
    {
        private readonly StubTripService _target;

        public TripServiceTests()
        {
            _target = new StubTripService();
        }

        [Fact]
        public void NotLoginThrowException()
        {
            _target.SetLoggedUser(null);
            Action act = () => _target.GetTripsByUser(new User());
            act.Should().Throw<UserNotLoggedInException>();
        }

        [Fact]
        public void EmptyList_Not_Friend()
        {
            _target.SetLoggedUser(new User());
            var actual = _target.GetTripsByUser(new User());
            actual.Should().BeNullOrEmpty();
        }
    }

    internal class StubTripService : TripService
    {
        private User _mockLoggedUser;

        public void SetLoggedUser(User user)
        {
            _mockLoggedUser = user;
        }

        protected override User GetLoggedUser()
        {
            return _mockLoggedUser;
        }
    }
}