namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public abstract class HandsetBrand
    {
        protected string Brand;
        protected Application Soft;

        public void Run()
        {
            Soft.Run(Brand);
        }
    }
}