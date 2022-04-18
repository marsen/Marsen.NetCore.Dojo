namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class GameContext
{
    public readonly string ReceiverName;

    public readonly string ServerName;
    private State _state;

    public GameContext(string serverName, string receiverName)
    {
        ServerName = serverName;
        ReceiverName = receiverName;
        _state = new SameState();
        _state.SetContext(this);
    }

    internal int ReceiverPoint { get; set; }
    internal int ServerPoint { get; set; }

    public string Score()
    {
        return _state.Score();
    }

    internal void ChangeState(State state)
    {
        _state = state;
        _state.SetContext(this);
    }

    public void ReceiverScore()
    {
        _state.ReceiverScore();
    }

    public void ServerScore()
    {
        _state.ServerScore();
    }
}