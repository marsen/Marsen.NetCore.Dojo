﻿namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class LoveFifteen : State
    {
        public override string Score()
        {
            return "Love Fifteen";
        }

        public override void ServerScore()
        {
            var state = new FifteenAll();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            var state = new LoveThirty();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }

    public class FifteenAll : State
    {
        public override string Score()
        {
            return "Fifteen All";
        }

        public override void ServerScore()
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiverScore()
        {
            throw new System.NotImplementedException();
        }
    }
}