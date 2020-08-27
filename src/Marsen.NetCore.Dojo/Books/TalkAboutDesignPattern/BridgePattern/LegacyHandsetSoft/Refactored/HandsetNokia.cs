namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public class HandsetNokia : HandsetBrand
    {
        public HandsetNokia(HandsetSoft soft)
        {
            Soft = soft;
            Brand = "Nokia";
        }


    }
}