using System;
using System.Runtime.Serialization;

namespace Marsen.NetCore.Dojo.Common;

[Serializable]
public class DojoException:Exception
{
    public DojoException()
    {
    }

    public DojoException(string message)
        : base(message)
    {
    }

    public DojoException(string message, Exception inner)
        : base(message, inner)
    {
    }
    // Without this constructor, deserialization will fail
    protected DojoException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {
    }
}