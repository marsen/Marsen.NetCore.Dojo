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
            ConsoleWriteLineShouldBeCall(target.Console,"Run Mark Address Book");
        }
        
        private void ConsoleWriteLineShouldBeCall(SystemConsole console, string message)
        {
            Assert.Equal(message, console.Message);
            Assert.Equal(1, console.WriteLineTimes);
        }
    }
}