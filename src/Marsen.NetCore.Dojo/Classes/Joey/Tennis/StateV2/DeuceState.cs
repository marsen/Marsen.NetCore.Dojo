namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2;

public class DeuceState : State
{
    public override string Score()
    {
        return "Deuce";
    }

    protected override void ChangeState()
    {
        Game.ChangeState(new AdvState());
    }
}