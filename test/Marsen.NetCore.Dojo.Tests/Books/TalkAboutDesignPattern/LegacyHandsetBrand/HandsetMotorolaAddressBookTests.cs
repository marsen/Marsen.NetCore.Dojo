using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class LegacyHandsetBrandTests
    {
        [Fact]
        public void HandsetMotorolaAddressBook_Run()
        {
            HandsetMotorolaAddressBook target = new HandsetMotorolaAddressBook();
            target.Run();
            Assert.Equal("Run Motorola Address Book", target.Console.Message);
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void HandsetNokiaAddressBook_Run()
        {
            var target = new HandsetNokiaAddressBook();
            target.Run();
            Assert.Equal("Run Nokia Address Book", target.Console.Message);
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void HandsetNokiaGame_Run()
        {
            var target = new HandsetNokiaGame();
            target.Run();
            Assert.Equal("Run Nokia Game", target.Console.Message);
            Assert.Equal(1, target.Console.WriteLineTimes);
        }
    }
}