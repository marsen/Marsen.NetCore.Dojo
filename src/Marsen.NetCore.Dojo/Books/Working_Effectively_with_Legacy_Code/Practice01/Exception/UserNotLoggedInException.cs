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

    [Obsolete("Obsolete:這個方法未被使用可以刪除，但是來自書中範例故保留")]
    protected UserNotLoggedInException(SerializationInfo info, StreamingContext context) : base(info,
        context)
    {
    }
}