using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand
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