using System;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; set; }
    }
}