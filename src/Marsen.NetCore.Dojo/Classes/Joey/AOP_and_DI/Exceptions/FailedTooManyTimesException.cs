using System;
using System.Runtime.Serialization;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Exceptions;

[Serializable]
public class FailedTooManyTimesException : Exception
{
    public string AccountId { get; init; }

    public FailedTooManyTimesException()
    {
    }

    public FailedTooManyTimesException(string message, System.Exception innerException) : base(
        message, innerException)
    {
    }

    public FailedTooManyTimesException(string message) : base(message)
    {
    }

    protected FailedTooManyTimesException(SerializationInfo info, StreamingContext context) : base(info,
        context)
    {
    } 
}