using System;

namespace Marsen.NetCore.Dojo.Common;

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
}