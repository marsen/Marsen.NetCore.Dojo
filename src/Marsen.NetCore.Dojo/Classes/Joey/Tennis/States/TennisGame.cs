namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

/// <summary>
/// TennisGame with Context
/// 狀態機版本 v1
/// </summary>
public class TennisGame
{
    public readonly string ReceiverName;
    public readonly string ServerName;

    public TennisGame(string serverName, string receiverName)
    {
        ReceiverName = receiverName;
        ServerName = serverName;
        State state = new SameState();
        state.SetContext(this);
        ChangeState(state);
    }

    public State State { get; private set; }
    public int ServerPoint { get; set; }
    public int ReceiverPoint { get; set; }

    public string Score()
    {
        return State.Score();
    }


    public void ChangeState(State state)
    {
        State = state;
    }
}