namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States
{
    public class DeuceState : State
    {
        public override string Score()
        {
            return "Deuce";
        }

        protected override void ChangeState()
        {
            State state = new AdvState();
            state.SetContext(Context);
            Context.ChangeState(state);
        }
    }
}