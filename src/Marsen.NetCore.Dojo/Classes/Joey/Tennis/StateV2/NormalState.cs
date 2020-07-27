namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2
{
    public class NormalState : State
    {
        public override string Score()
        {
            return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
        }

        protected override void ChangeState()
        {
            State state = IsReadyToWin() ? (State) new WinState() : new NormalState();

            if (IsSame())
            {
                state = Context.ServerPoint >= 3 ? (State) new DeuceState() : new SameState();
            }

            Context.ChangeState(state);
        }

        private bool IsReadyToWin()
        {
            return Context.ServerPoint > 3 || Context.ReceiverPoint > 3;
        }
    }
}