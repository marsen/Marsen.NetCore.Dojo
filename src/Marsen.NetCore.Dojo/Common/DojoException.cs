using System;

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
}