namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class NormalState : State
{
    public override string Score()
    {
        return $"{ScoreLookup[Game.ServerPoint]} {ScoreLookup[Game.ReceiverPoint]}";
    }

    protected override void ChangeState()
    {
        State state = IsReadyToWin() ? new WinState() : new NormalState();

        if (IsSame()) state = Game.ServerPoint >= 3 ? new DeuceState() : new SameState();

        Game.ChangeState(state);
    }

    private bool IsReadyToWin()
    {
        return Game.ServerPoint > 3 || Game.ReceiverPoint > 3;
    }
}