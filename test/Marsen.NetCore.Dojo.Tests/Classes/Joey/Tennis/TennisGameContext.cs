namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContext
    {
        public TennisGameContext(State state)
        {
            this.State = state;
            state.SetContext(this);
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