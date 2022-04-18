using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class GameIsOverException : Exception
{
    public GameIsOverException(string s):base(s)
    {
    }
}