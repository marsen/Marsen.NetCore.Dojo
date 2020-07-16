﻿namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class ThirtyLove : State
    {
        public override string Score()
        {
            return "Thirty Love";
        }

        public override void ServerScore()
        {
            var state = new FortyLove();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            throw new System.NotImplementedException();
        }
    }
}