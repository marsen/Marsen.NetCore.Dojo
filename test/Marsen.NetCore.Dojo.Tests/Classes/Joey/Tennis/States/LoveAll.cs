namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class LoveAll : State
    {
        public override string Score()
        {
            return "Love All";
        }

        public override void ServerScore()
        {
            Context.ServerPoint++;
            var state = new NormalState();
            state.SetContext(this.Context);
            Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            //var state = new LoveFifteen();
            var state = new NormalState();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }

    public class NormalState : State
    {
        public override string Score()
        {
            return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
        }

        public override void ServerScore()
        {
            Context.ServerPoint++;
            State state = new NormalState();
            if (Context.ServerPoint == Context.ReceiverPoint)
            {
                state = new FifteenAll();
            }
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            State state = new NormalState();
            if (Context.ServerPoint == Context.ReceiverPoint)
            {
                state = new FifteenAll();
            }

            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}