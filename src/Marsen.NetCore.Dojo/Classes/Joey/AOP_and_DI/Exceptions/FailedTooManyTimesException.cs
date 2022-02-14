using System;
using System.Runtime.Serialization;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Exceptions;

[Serializable]
public class FailedTooManyTimesException : Exception
{
    private readonly string _accountId;

    public string AccountId
    {
        get => _accountId;
        init => _accountId = value;
    }

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