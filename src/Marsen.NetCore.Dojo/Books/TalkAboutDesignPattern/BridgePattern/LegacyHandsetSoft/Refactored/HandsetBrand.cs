namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public abstract class HandsetBrand
    {
        protected HandsetSoft Soft;
        protected string Brand;
        public void Run()
        {
            this.Soft.Run(Brand);
        }
    }
}