using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand
{
    public sealed class HandsetNokia : HandsetBrand
    {
        public HandsetNokia(Application app):base(app)
        {
            Brand = "Nokia";
        }
    }
}