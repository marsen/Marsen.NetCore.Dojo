using System.Text;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class HandsetMotorola:HandsetBrand
    {
        public override void Run()
        {
            var handsetGame = new HandsetGame("Motorola");
            handsetGame.Run();
        }
    }
}