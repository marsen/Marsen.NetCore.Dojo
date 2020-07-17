using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class WinState : State
    {
        public override string Score()
        {
            return $"{Winner()} Win";
        }


        public override void ServerScore()
        {
            throw new NotImplementedException();
        }

        public override void ReceiverScore()
        {
            throw new NotImplementedException();
        }
    }
}