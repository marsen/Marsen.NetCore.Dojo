using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis;

/// <summary>
/// TennisGame
/// 無狀態機的版本
/// </summary>
public class TennisGame
{
    private readonly string _firstPlayerName;

    private readonly Dictionary<int, string> _scoreLookup = new()
    {
        {0, "Love"},
        {1, "Fifteen"},
        {2, "Thirty"},
        {3, "Forty"}
    };

    private readonly string _secondPlayerName;
    private int _firstPlayerScore;

    private int _secondPlayerScore;

    /// <summary>
    /// Initializes a new instance of the <see cref="TennisGame" /> class.
    /// </summary>
    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public string Score()
    {
        return IsSameScore()
            ? DrawScore()
            : SeesawScore();
    }

    private string SeesawScore()
    {
        return IsReadyForWin() ? AdvScore() : NormalScore();
    }

    private string DrawScore()
    {
        return IsOverForty() ? Deuce : SameScore();
    }

    private bool IsOverForty()
    {
        return _firstPlayerScore >= 3;
    }

    private const string Deuce = "Deuce";

    private string NormalScore()
    {
        return $"{_scoreLookup[_firstPlayerScore]} {_scoreLookup[_secondPlayerScore]}";
    }

    private string SameScore()
    {
        return $"{_scoreLookup[_firstPlayerScore]} All";
    }

    private string AdvScore()
    {
        return $"{GetWinnerName()} {(IsLeading() ? "Win" : "Adv")}";
    }

    private bool IsLeading()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore) > 1;
    }

    private string GetWinnerName()
    {
        return _firstPlayerScore > _secondPlayerScore ? _firstPlayerName : _secondPlayerName;
    }

    private bool IsReadyForWin()
    {
        return _firstPlayerScore > 3 || _secondPlayerScore > 3;
    }

    private bool IsSameScore()
    {
        return _firstPlayerScore == _secondPlayerScore;
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScore++;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerScore++;
    }
}