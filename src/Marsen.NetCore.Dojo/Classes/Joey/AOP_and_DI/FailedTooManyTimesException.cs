using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI
{
    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; set; }
    }
}