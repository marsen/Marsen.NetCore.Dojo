using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.User;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.Working_Effectively_with_Legacy_Code
{
    public class TripServiceTest
    {
        private readonly StubTripService _target;

        public TripServiceTest()
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