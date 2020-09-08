using System;
using System.Linq;
using Castle.DynamicProxy;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggerInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            if (Attribute.GetCustomAttribute(invocation.Method, typeof(LogAttribute)) is LogAttribute != false)
            {
                _logger.Log($"log by interceptor:{invocation.TargetType.FullName}.{invocation.Method.Name}():" +
                            $"{string.Join("-", (invocation.Arguments.Select(x => (x ?? "").ToString())))}");
            }

            invocation.Proceed();
        }
    }

    public class LogAttribute : Attribute
    {
    }
}