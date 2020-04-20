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
        [Fact]
        public void NotLoginThrowException()
        {
            var target = new TripService();
            Action act = () => target.GetTripsByUser(new User());
            act.Should().Throw<UserNotLoggedInException>();
        }
    }
}