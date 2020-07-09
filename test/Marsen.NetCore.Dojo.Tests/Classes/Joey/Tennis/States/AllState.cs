﻿namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class AllState : NormalState
    {
        public override void ReceiverScore()
        {
            Score = "Fifteen All";
        }

        public override void ServerScore()
        {
            Score = "Fifteen All";
        }
    }
}