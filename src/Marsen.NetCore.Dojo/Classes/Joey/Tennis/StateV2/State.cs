using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public abstract class State
{
    protected readonly Dictionary<int, string> ScoreLookup = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" }
    };

    protected GameContext Context;

    public abstract string Score();

    public void SetContext(GameContext context)
    {
        Context = context;
    }

    public void ServerScore()
    {
        Context.ServerPoint++;
        ChangeState();
    }

    public void ReceiverScore()
    {
        Context.ReceiverPoint++;
        ChangeState();
    }

    protected abstract void ChangeState();

    protected string Winner()
    {
        return Context.ServerPoint > Context.ReceiverPoint
            ? Context.ServerName
            : Context.ReceiverName;
    }

    protected bool IsSame()
    {
        return Context.ServerPoint == Context.ReceiverPoint;
    }
}