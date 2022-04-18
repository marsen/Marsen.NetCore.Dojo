namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

public class SameState : State
{
    public override string Score()
    {
        return $"{ScoreLookup[Game.ServerPoint]} All";
    }

    protected override void ChangeState()
    {
        State state = new NormalState();
        state.SetContext(Game);
        Game.ChangeState(state);
    }
}