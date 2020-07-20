using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class WinState : State
    {
        public override string Score()
        {
            return $"{Winner()} Win";
        }

        protected override void ChangeState()
        {
            throw new NotImplementedException();
        }
    }
}