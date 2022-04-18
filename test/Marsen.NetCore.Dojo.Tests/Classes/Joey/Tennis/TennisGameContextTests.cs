using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.Tennis;
using Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;
using Xunit;
using TennisGame = Marsen.NetCore.Dojo.Classes.Joey.Tennis.States.TennisGame;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis;

/// <summary>
/// TennisGame with Context Test Cases
/// 狀態機版本 v1 測試案例
/// </summary>
public class TennisGameContextTests
{
    private readonly TennisGame _tennisGame;

    public TennisGameContextTests()
    {
        _tennisGame = new TennisGame("Mark", "Iris");
    }

    [Fact]
    public void Love_All()
    {
        ScoreShouldBe("Love All");
    }

    [Fact]
    public void Fifteen_Love()
    {
        GivenServerPoint(1);
        ScoreShouldBe("Fifteen Love");
    }

    [Fact]
    public void Love_Fifteen()
    {
        GivenReceiverPoint(1);
        ScoreShouldBe("Love Fifteen");
    }

    [Fact]
    public void Love_Thirty()
    {
        GivenReceiverPoint(2);
        ScoreShouldBe("Love Thirty");
    }

    [Fact]
    public void Love_Forty()
    {
        GivenReceiverPoint(3);
        ScoreShouldBe("Love Forty");
    }

    [Fact]
    public void Fifteen_All()
    {
        GivenServerPoint(1);
        GivenReceiverPoint(1);
        ScoreShouldBe("Fifteen All");
    }

    [Fact]
    public void LoveFifteen_To_FifteenAll()
    {
        GivenReceiverPoint(1);
        GivenServerPoint(1);
        ScoreShouldBe("Fifteen All");
    }


    [Fact]
    public void Thirty_Love()
    {
        GivenServerPoint(2);
        ScoreShouldBe("Thirty Love");
    }

    [Fact]
    public void Forty_Love()
    {
        GivenServerPoint(3);
        ScoreShouldBe("Forty Love");
    }

    [Fact]
    public void Forty_Fifteen()
    {
        GivenServerPoint(3);
        GivenReceiverPoint(1);
        ScoreShouldBe("Forty Fifteen");
    }

    [Fact]
    public void Fifteen_Thirty()
    {
        GivenServerPoint(1);
        GivenReceiverPoint(2);
        ScoreShouldBe("Fifteen Thirty");
    }

    [Fact]
    public void Thirty_Fifteen()
    {
        GivenServerPoint(2);
        GivenReceiverPoint(1);
        ScoreShouldBe("Thirty Fifteen");
    }

    [Fact]
    public void FifteenAll_To_ThirtyFifteen()
    {
        GivenServerPoint(1);
        GivenReceiverPoint(1);
        GivenServerPoint(1);
        ScoreShouldBe("Thirty Fifteen");
    }

    [Fact]
    public void FifteenAll_To_FifteenThirty()
    {
        GivenReceiverPoint(1);
        GivenServerPoint(1);
        GivenReceiverPoint(1);
        ScoreShouldBe("Fifteen Thirty");
    }

    [Fact]
    public void ThirtyAll()
    {
        GivenReceiverPoint(2);
        GivenServerPoint(2);
        ScoreShouldBe("Thirty All");
    }

    [Fact]
    public void FifteenForty()
    {
        GivenServerPoint(1);
        GivenReceiverPoint(3);
        ScoreShouldBe("Fifteen Forty");
    }

    [Fact]
    public void FortyFifteen()
    {
        GivenServerPoint(3);
        GivenReceiverPoint(1);
        ScoreShouldBe("Forty Fifteen");
    }

    [Fact]
    public void FortyThirty()
    {
        GivenServerPoint(3);
        GivenReceiverPoint(2);
        ScoreShouldBe("Forty Thirty");
    }

    [Fact]
    public void ThirtyForty()
    {
        GivenServerPoint(2);
        GivenReceiverPoint(3);
        ScoreShouldBe("Thirty Forty");
    }

    [Fact]
    public void Deuce()
    {
        GivenDeuce();
        ScoreShouldBe("Deuce");
    }

    private void GivenDeuce()
    {
        GivenServerPoint(3);
        GivenReceiverPoint(3);
    }

    [Fact]
    public void Deuce_When_4_4_After_ServerScore()
    {
        GivenDeuce();
        GivenReceiverPoint(1);
        GivenServerPoint(1);
        ScoreShouldBe("Deuce");
    }

    [Fact]
    public void Deuce_When_4_4_After_ReceiverScore()
    {
        GivenDeuce();
        GivenServerPoint(1);
        GivenReceiverPoint(1);
        ScoreShouldBe("Deuce");
    }


    [Fact]
    public void ServerAdv()
    {
        GivenDeuce();
        GivenServerPoint(1);
        ScoreShouldBe("Mark Adv");
    }

    [Fact]
    public void ReceiverAdv()
    {
        GivenDeuce();
        GivenReceiverPoint(1);
        ScoreShouldBe("Iris Adv");
    }

    [Fact]
    public void ReceiverWin()
    {
        GivenDeuce();
        GivenReceiverPoint(2);
        ScoreShouldBe("Iris Win");
    }

    [Fact]
    public void ServerWin()
    {
        GivenDeuce();
        GivenServerPoint(2);
        ScoreShouldBe("Mark Win");
    }

    [Fact]
    public void Server_Win_When_4_0()
    {
        GivenServerPoint(4);
        ScoreShouldBe("Mark Win");
    }

    [Fact]
    public void After_Server_Win_Score_Should_Throw_Exception()
    {
        GivenServerPoint(4);
        var act = () => GivenServerPoint(1);
        act.Should().Throw<GameIsOverException>();
    }

    [Fact]
    public void Receiver_Win_When_0_4()
    {
        GivenReceiverPoint(4);
        ScoreShouldBe("Iris Win");
    }

    [Fact]
    public void Receiver_Win_When_1_4()
    {
        GivenServerPoint(1);
        GivenReceiverPoint(4);
        ScoreShouldBe("Iris Win");
    }


    private void GivenServerPoint(int times)
    {
        for (var i = 0; i < times; i++) _tennisGame.State.ServerScore();
    }


    private void GivenReceiverPoint(int times)
    {
        for (var i = 0; i < times; i++) _tennisGame.State.ReceiverScore();
    }


    private void ScoreShouldBe(string expected)
    {
        Assert.Equal(expected, _tennisGame.Score());
    }
}