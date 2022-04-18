using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

public abstract class State
{
    protected readonly Dictionary<int, string> ScoreLookup = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" }
    };

    protected TennisGame Game;
    public abstract string Score();

    public void SetContext(TennisGame tennisGame)
    {
        Game = tennisGame;
    }

    protected bool IsSamePoint()
    {
        return Game.ServerPoint == Game.ReceiverPoint;
    }

    protected string Winner()
    {
        return Game.ServerPoint >= Game.ReceiverPoint
            ? Game.ServerName
            : Game.ReceiverName;
    }

    public void ServerScore()
    {
        Game.ServerPoint++;
        ChangeState();
    }

    public void ReceiverScore()
    {
        Game.ReceiverPoint++;
        ChangeState();
    }

    protected abstract void ChangeState();
}