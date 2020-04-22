using Castle.DynamicProxy;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;
using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interceptors
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
            if (Attribute.GetCustomAttribute(invocation.Method, typeof(LogAttribute)) is LogAttribute logAttribute ==
                false)
            {
                invocation.Proceed();
            }
            else
            {
                _logger.Log($"log by interceptor:{invocation.TargetType.FullName}.{invocation.Method.Name}():" +
                            $"{string.Join("-", (invocation.Arguments.Select(x => (x ?? "").ToString())))}");

                invocation.Proceed();
            }
        }
    }

    public class LogAttribute : Attribute
    {
    }
}