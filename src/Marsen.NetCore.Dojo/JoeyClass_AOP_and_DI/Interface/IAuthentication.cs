namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface
{
    public interface IAuthentication
    {
        bool Verify(string accountId, string password, string otp);
    }
}