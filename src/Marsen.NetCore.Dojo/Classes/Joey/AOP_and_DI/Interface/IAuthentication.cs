using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interceptors;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface
{
    public interface IAuthentication
    {
        [Log]
        bool Verify(string accountId, string password, string otp);
    }
}