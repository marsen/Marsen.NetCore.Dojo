namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored
{
    public sealed class HandsetMotorola:HandsetBrand
    {
        public void Run()
        {
            App.Run(Band);
        }

        public HandsetMotorola(Application app) : base(app)
        {
            Band ="Motorola";
        }
    }
}