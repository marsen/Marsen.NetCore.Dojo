using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis;

/// <summary>
/// Tennis Game Context
/// 狀態機版本v2 的 test case
/// </summary>
public class GameContextTests
{
    private readonly TennisGame _context = new("Sam", "Ben");

    [Fact]
    public void LoveAll()
    {
        ScoreShouldBe("Love All");
    }

    [Fact]
    public void LoveFifteen()
    {
        GiveReceiverScore(1);
        ScoreShouldBe("Love Fifteen");
    }

    [Fact]
    public void LoveThirty()
    {
        GiveReceiverScore(2);
        ScoreShouldBe("Love Thirty");
    }

    [Fact]
    public void LoveForty()
    {
        GiveReceiverScore(3);
        ScoreShouldBe("Love Forty");
    }

    [Fact]
    public void ReceiverWin()
    {
        GiveReceiverScore(4);
        ScoreShouldBe("Ben Win");
    }


    [Fact]
    public void FifteenForty()
    {
        GiveReceiverScore(3);
        GiveServerScore(1);
        ScoreShouldBe("Fifteen Forty");
    }


    [Fact]
    public void FifteenLove()
    {
        GiveServerScore(1);
        ScoreShouldBe("Fifteen Love");
    }

    [Fact]
    public void ThirtyLove()
    {
        GiveServerScore(2);
        ScoreShouldBe("Thirty Love");
    }

    [Fact]
    public void ThirtyFifteen()
    {
        GiveServerScore(2);
        GiveReceiverScore(1);
        ScoreShouldBe("Thirty Fifteen");
    }


    [Fact]
    public void FortyLove()
    {
        GiveServerScore(3);
        ScoreShouldBe("Forty Love");
    }

    [Fact]
    public void ServerWin()
    {
        GiveServerScore(4);
        ScoreShouldBe("Sam Win");
    }

    [Fact]
    public void After_Receiver_Win_Score_Should_Throw_Exception()
    {
        // Arrange
        GiveReceiverScore(4);
        // Act
        var act = () => GiveReceiverScore(1);
        // Assert
        act.Should().Throw<GameIsOverException>().WithMessage("Winner is Ben");
    }

    [Fact]
    public void After_Server_Win_Score_Should_Throw_Exception()
    {
        // Arrange
        GiveServerScore(4);
        // Act
        var act = () => GiveServerScore(1);
        // Assert
        act.Should().Throw<GameIsOverException>().WithMessage("Winner is Sam");
    }

    [Fact]
    public void FifteenAll()
    {
        GiveServerScore(1);
        GiveReceiverScore(1);
        ScoreShouldBe("Fifteen All");
    }

    [Fact]
    public void ThirtyAll()
    {
        GiveReceiverScore(2);
        GiveServerScore(2);
        ScoreShouldBe("Thirty All");
    }

    [Fact]
    public void Deuce()
    {
        GivenDeuce(3);
        ScoreShouldBe("Deuce");
    }

    [Fact]
    public void ServerAdv()
    {
        GivenDeuce(3);
        GiveServerScore(1);
        ScoreShouldBe("Sam Adv");
    }

    [Fact]
    public void ServerWinAfterDeuce()
    {
        GivenDeuce(3);
        GiveServerScore(2);
        ScoreShouldBe("Sam Win");
    }


    [Fact]
    public void ReceiverAdv()
    {
        GivenDeuce(3);
        GiveReceiverScore(1);
        ScoreShouldBe("Ben Adv");
    }

    [Fact]
    public void ReceiverWinAfterDeuce()
    {
        GivenDeuce(3);
        GiveReceiverScore(2);
        ScoreShouldBe("Ben Win");
    }


    [Fact]
    public void Deuce_When_4_4()
    {
        GivenDeuce(3);
        GiveReceiverScore(1);
        GiveServerScore(1);
        ScoreShouldBe("Deuce");
    }

    [Fact]
    public void Deuce_When_100_100()
    {
        GivenDeuce(100);
        ScoreShouldBe("Deuce");
    }

    private void GivenDeuce(int times)
    {
        for (var i = 0; i < times; i++)
        {
            GiveReceiverScore(1);
            GiveServerScore(1);
        }
    }

    private void GiveServerScore(int times)
    {
        for (var i = 0; i < times; i++) _context.ServerScore();
    }

    private void GiveReceiverScore(int times)
    {
        for (var i = 0; i < times; i++) _context.ReceiverScore();
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.Equal(expected, _context.Score());
    }
}