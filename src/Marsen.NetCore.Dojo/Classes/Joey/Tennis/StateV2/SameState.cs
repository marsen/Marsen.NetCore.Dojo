namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class SameState : State
{
    public override string Score()
    {
        return $"{ScoreLookup[Game.ServerPoint]} All";
    }

    protected override void ChangeState()
    {
        Game.ChangeState(new NormalState());
    }
}