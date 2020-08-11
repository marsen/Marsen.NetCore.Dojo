namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored
{
    public sealed class HandsetNokia : HandsetBrand
    {
        public HandsetNokia(Application app):base(app)
        {
            Band = "Nokia";
        }
        public void Run()
        {
            this.App.Run(Band);
        }
    }
}