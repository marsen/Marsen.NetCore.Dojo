using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Exceptions
{
    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; init; }
    }
}