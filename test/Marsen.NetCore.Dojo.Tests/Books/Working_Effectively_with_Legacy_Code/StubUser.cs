using System.Collections.Generic;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;

namespace Marsen.NetCore.Dojo.Tests.Books.Working_Effectively_with_Legacy_Code
{
    internal class StubUser : User
    {
        private List<User> _mockFriendsList;

        public override List<User> GetFriends()
        {
            return _mockFriendsList;
        }

        public void SetFriends(List<User> friends)
        {
            _mockFriendsList = friends;
        }
    }
}