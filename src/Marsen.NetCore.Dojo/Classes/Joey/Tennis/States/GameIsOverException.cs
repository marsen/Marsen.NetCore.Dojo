using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

public class GameIsOverException : Exception
{
    public GameIsOverException(string s) : base(s)
    {
    }
}