﻿using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern
{
    public class LegacyHandsetSoftTests
    {
        [Fact]
        public void AddressBook_Run()
        {
            var target = new AddressBook();
            target.Run("Mark");
            ConsoleWriteLineShouldBeCall(target.Console, "Run Mark Address Book");
        }

        [Fact]
        public void Game_Run()
        {
            var target = new Game();
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

        [Fact]
        public void HandsetNokiaAddressBook_Run()
        {
            var target = new HandsetNokiaAddressBook();
            target.Run();
            ConsoleWriteLineShouldBeCall(target.Console, "Run Nokia Address Book");
        }

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
        public void HandsetBrand_Run()
        {
            var mockApp = new MockApplication();
            var target = new MockHandsetBrand(mockApp);
            target.Run();
            Assert.Equal(1, mockApp.CallTimes);
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
            public int CallTimes { get; private set; }

            public override void Run(string brand)
            {
                CallTimes++;
            }
        }
    }
}