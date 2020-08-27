using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern
{
    public class LegacyHandsetSoftTests
    {
        [Fact]
        public void HandsetAddressBook_Run()
        {
            var target = new HandsetAddressBook();
            target.Run("Mark");
            ConsoleWriteLineShouldBeCall(target.Console, "Run Mark Address Book");
        }

        [Fact]
        public void HandsetGame_Run()
        {
            var target = new HandsetGame();
            target.Run("Mark");
            ConsoleWriteLineShouldBeCall(target.Console, "Run Mark Game");
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