using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand
{
    public class HandsetBrand
    {
        protected readonly Application App;
        protected string Band;

        protected HandsetBrand(Application app)
        {
            App = app;
        }
    }
}