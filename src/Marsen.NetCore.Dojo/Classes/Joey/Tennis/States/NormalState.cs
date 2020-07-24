namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override string Score()
        {
            if (Context.ServerPoint < 4 && Context.ReceiverPoint < 4)
            {
                return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
            }

            return "";
        }

        protected override void ChangeState()
        {
            State state = new NormalState();
            if (IsSamePoint())
            {
                state = Context.ServerPoint >= 3 ? (State) new DeuceState() : new SameState();
            }

            if (Context.ServerPoint >= 4 || Context.ReceiverPoint >= 4)
            {
                state = new WinState();
            }

            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}