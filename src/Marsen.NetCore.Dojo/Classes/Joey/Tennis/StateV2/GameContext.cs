namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2
{
    public class GameContext
    {
        private State _state;

        public GameContext(string serverName, string receiverName)
        {
            ServerName = serverName;
            ReceiverName = receiverName;
            _state = new SameState();
            _state.SetContext(this);
        }

        public string Score() => _state.Score();

        internal void ChangeState(State state)
        {
            _state = state;
            _state.SetContext(this);
        }

        public void ReceiverScore() => _state.ReceiverScore();
        internal int ReceiverPoint { get; set; }
        public void ServerScore() => _state.ServerScore();
        internal int ServerPoint { get; set; }

        public readonly string ServerName;

        public readonly string ReceiverName;
    }
}