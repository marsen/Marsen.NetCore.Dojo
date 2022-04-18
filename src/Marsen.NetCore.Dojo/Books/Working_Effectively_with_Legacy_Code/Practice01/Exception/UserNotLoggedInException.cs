using System;
using System.Runtime.Serialization;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;

[Serializable]
public class UserNotLoggedInException : System.Exception
{
    public UserNotLoggedInException()
    {
    }

    public UserNotLoggedInException(string message, System.Exception innerException) : base(
        message, innerException)
    {
    }

    public UserNotLoggedInException(string message) : base(message)
    {
    }

    protected UserNotLoggedInException(SerializationInfo info, StreamingContext context) : base(info,
        context)
    {
    }
}