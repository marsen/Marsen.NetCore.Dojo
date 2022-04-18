namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public class HandsetMotorola : HandsetBrand
    {
        public HandsetMotorola(Application soft)
        {
            Soft = soft;
            Brand = "Motorola";
        }
    }
}