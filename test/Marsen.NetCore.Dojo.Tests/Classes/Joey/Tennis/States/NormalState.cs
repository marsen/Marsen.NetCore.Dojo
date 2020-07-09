namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override string ServerScore()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                return _gameContext.State.ReceiverScore();
            }
            return "Fifteen Love";
        }

        public override string ReceiverScore()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                return _gameContext.State.ReceiverScore();
            }
            
            return "Love Fifteen";
        }
    }
}