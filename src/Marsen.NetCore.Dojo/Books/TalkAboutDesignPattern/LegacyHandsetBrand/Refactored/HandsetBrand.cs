namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored
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