using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Brand;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Books.TalkAboutDesignPattern
{
    public class LegacyHandsetBrandTests
    {
        [Fact]
        public void Motorola_Run_Game()
        {
            var app = new Game();
            var target = new HandsetMotorola(app);
            target.Run();
            Assert.Equal(1, app.Console.WriteLineTimes);
        }

        [Fact]
        public void Nokia_Run_Game()
        {
            var app = new Game();
            var target = new HandsetNokia(app);
            target.Run();
            Assert.Equal(1, app.Console.WriteLineTimes);
        }
    }
}