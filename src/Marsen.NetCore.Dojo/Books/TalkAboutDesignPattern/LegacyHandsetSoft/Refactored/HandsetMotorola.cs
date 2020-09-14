namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft.Refactored
{
    public class HandsetMotorola : HandsetBrand
    {
        public HandsetMotorola(HandsetSoft soft)
        {
            Soft = soft;
            Brand = "Motorola";
        }

        public override void Run()
        {
            this.Soft.Run(Brand);
        }
    }
}