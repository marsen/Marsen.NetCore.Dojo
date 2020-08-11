namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored
{
    public class HandsetMotorola:HandsetBrand
    {
        public override void Run()
        {
            App.Run(Band);
        }

        public HandsetMotorola(HandsetApp app) : base(app)
        {
            Band ="Motorola";
        }
    }
}