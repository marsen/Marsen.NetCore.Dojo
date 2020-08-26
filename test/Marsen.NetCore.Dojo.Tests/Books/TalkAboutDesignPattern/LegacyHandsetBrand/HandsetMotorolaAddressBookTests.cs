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
            ConsoleWriteLineShouldBeCall(target.Console, "Run Motorola Address Book");
        }

        [Fact]
        public void HandsetMotorolaGame_Run()
        {
            var target = new HandsetMotorolaGame();
            target.Run();
            ConsoleWriteLineShouldBeCall(target.Console, "Run Motorola Game");
        }


        [Fact]
        public void HandsetNokiaAddressBook_Run()
        {
            var target = new HandsetNokiaAddressBook();
            target.Run();
            ConsoleWriteLineShouldBeCall(target.Console, "Run Nokia Address Book");
        }

        [Fact]
        public void HandsetNokiaGame_Run()
        {
            var target = new HandsetNokiaGame();
            target.Run();
            ConsoleWriteLineShouldBeCall(target.Console, "Run Nokia Game");
        }

        private void ConsoleWriteLineShouldBeCall(SystemConsole console, string message)
        {
            Assert.Equal(message, console.Message);
            Assert.Equal(1, console.WriteLineTimes);
        }
    }
}