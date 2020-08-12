namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public abstract class HandsetBrand
    {
        protected HandsetSoft Soft;
        protected string Brand;
        public abstract void Run();
    }
}