namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft.Refactored
{
    public class HandsetNokia : HandsetBrand
    {
        public HandsetNokia(HandsetSoft soft)
        {
            Soft = soft;
            Brand = "Nokia";
        }

        public override void Run()
        {
            this.Soft.Run(Brand);
        }
    }
}