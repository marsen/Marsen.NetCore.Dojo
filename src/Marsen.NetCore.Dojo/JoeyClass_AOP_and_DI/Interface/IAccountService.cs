namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface
{
    public interface IAccountService
    {
        bool IsLocked(string accountId);
        void ResetFailedCounter(string accountId);
        void AddFailedCounter(string accountId);
        string FailedCount(string accountId);
    }
}