using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class LegacyHandsetBrandTests
    {
        [Fact]
        public void HandsetMotorolaAddressBook_Run()
        {
            var target = new HandsetMotorolaAddressBook();
            target.Run();
            var console = target.Console;
            ConsoleWriteLineShouldBeCall(console, "Run Motorola Address Book");
        }

        private void ConsoleWriteLineShouldBeCall(SystemConsole console, string message)
        {
            Assert.Equal(message, console.Message);
            Assert.Equal(1, console.WriteLineTimes);
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