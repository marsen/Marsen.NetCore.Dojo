namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class SameState : State
{
    public override string Score()
    {
        return $"{ScoreLookup[Context.ServerPoint]} All";
    }

    protected override void ChangeState()
    {
        Context.ChangeState(new NormalState());
    }
}