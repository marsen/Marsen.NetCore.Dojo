using System;
using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States
{
    public class AdvState : State
    {
        public override string Score()
        {
            return $"{Winner()} Adv";
        }

        protected override void ChangeState()
        {
            State state = Context.ServerPoint == Context.ReceiverPoint ? (State) new DeuceState() : new WinState();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}