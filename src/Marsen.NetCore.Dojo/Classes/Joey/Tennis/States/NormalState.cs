namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States;

public class NormalState : State
{
    public override string Score()
    {
        return $"{ScoreLookup[Game.ServerPoint]} {ScoreLookup[Game.ReceiverPoint]}";
    }

    protected override void ChangeState()
    {
        State state = new NormalState();
        if (IsSamePoint()) state = Game.ServerPoint >= 3 ? new DeuceState() : new SameState();

        if (Game.ServerPoint >= 4 || Game.ReceiverPoint >= 4) state = new WinState();

        state.SetContext(Game);
        Game.ChangeState(state);
    }
}