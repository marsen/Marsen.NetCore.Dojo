namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class NLogLogger
    {
        public void Log(string message)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info(message);
        }
    }
}