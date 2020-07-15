namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class LoveAll : State
    {
        public override string Score()
        {
            return "Love All";
        }

        public override void ServerScore()
        {
            var fifteenLove = new FifteenLove();
            this.Context.ChangeState(fifteenLove);
        }
    }
}