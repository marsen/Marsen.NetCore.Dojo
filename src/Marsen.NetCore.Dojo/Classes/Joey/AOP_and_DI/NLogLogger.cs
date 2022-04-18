using NLog;
using ILogger = Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface.ILogger;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI;

public class NLogLogger : ILogger
{
    public void Log(string message)
    {
        var logger = LogManager.GetCurrentClassLogger();
        logger.Info(message);
    }
}