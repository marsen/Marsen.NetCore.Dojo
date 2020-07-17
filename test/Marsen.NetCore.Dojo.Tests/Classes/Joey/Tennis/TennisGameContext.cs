using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContext
    {
        public readonly string ReceiverPlayer;
        public readonly string ServerPlayer;

        public TennisGameContext(string serverPlayer, string receiverPlayer)
        {
            ReceiverPlayer = receiverPlayer;
            ServerPlayer = serverPlayer;
            State state = new SameState();
            state.SetContext(this);
            ChangeState(state);
        }

        public string Score()
        {
            return State.Score();
        }

        public State State { get; private set; }
        public int ServerPoint { get; set; }
        public int ReceiverPoint { get; set; }


        public void ChangeState(State state)
        {
            this.State = state;
        }
    }
}