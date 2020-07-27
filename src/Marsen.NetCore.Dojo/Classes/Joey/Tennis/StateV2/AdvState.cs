namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.StateV2
{
    public class AdvState : State
    {
        public override string Score()
        {
            return $"{Winner()} Adv";
        }

        protected override void ChangeState()
        {
            if (IsSame())
            {
                Context.ChangeState(new DeuceState());
            }
            else
            {
                Context.ChangeState(new WinState());
            }
        }
    }
}