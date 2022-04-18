using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users
{
    public class UserSession
    {
        private static readonly UserSession userSession = new();

        private UserSession()
        {
        }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public static bool IsUserLoggedIn(User user)
        {
            throw new DependentClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependentClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}