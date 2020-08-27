using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Books.TalkAboutDesignPattern
{
    public class LegacyHandsetSoftTests
    {
        [Fact]
        public void HandsetMotorola_Run_Game()
        {
            var app = new Game();
            var target = new HandsetMotorola(app);
            target.Run();
            ConsoleWriteLineShouldBeCall(app.Console, "Run Motorola Game");
        }

        [Fact]
        public void HandsetNokia_Run_Game()
        {
            var app = new Game();
            var target = new HandsetNokia(app);
            target.Run();
            ConsoleWriteLineShouldBeCall(app.Console, "Run Nokia Game");
        }

        [Fact]
        public void HandsetMotorola_Run_AddressBook()
        {
            var app = new AddressBook();
            var target = new HandsetMotorola(app);
            target.Run();
            ConsoleWriteLineShouldBeCall(app.Console, "Run Motorola Address Book");
        }

        [Fact]
        public void HandsetNokia_Run_AddressBook()
        {
            var app = new AddressBook();
            var target = new HandsetNokia(app);
            target.Run();
            ConsoleWriteLineShouldBeCall(app.Console, "Run Nokia Address Book");
        }

        private void ConsoleWriteLineShouldBeCall(SystemConsole console, string message)
        {
            Assert.Equal(message, console.Message);
            Assert.Equal(1, console.WriteLineTimes);
        }

        private class MockHandsetBrand : HandsetBrand
        {
            public MockHandsetBrand(Application soft)
            {
                Soft = soft;
            }
        }

        private class MockApplication : Application
        {
            public override void Run(string brand)
            {
                CallTimes++;
            }

            public int CallTimes { get; private set; }
        }
    }
}