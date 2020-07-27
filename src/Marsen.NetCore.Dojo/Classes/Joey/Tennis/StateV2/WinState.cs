using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2
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