using Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis;

public class TennisGameContext
{
    public readonly string ReceiverName;
    public readonly string ServerName;

    public TennisGameContext(string serverName, string receiverName)
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