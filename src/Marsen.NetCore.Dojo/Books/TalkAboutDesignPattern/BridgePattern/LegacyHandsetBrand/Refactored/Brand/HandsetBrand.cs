using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Brand
{
    public class HandsetBrand
    {
        private readonly Application _app;
        protected string Brand;

        protected HandsetBrand(Application app)
        {
            _app = app;
        }

        public void Run()
        {
            this._app.Run(Brand);
        }
    }
}