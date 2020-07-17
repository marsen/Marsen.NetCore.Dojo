namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class DeuceState : State
    {
        public override string Score()
        {
            return "Deuce";
        }

        public override void ServerScore()
        
        {
            Context.ServerPoint++;
            ChangeState();
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }

        private void ChangeState()
        {
            State state = new NormalState();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}