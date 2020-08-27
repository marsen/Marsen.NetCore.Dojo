using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Bridge
{
    public static class Soft
    {
        public static void Start()
        {
            var nokiaGame = new HandsetNokiaGame();
            nokiaGame.Run();
            var nokiaAddressBook = new HandsetNokiaAddressBook();
            nokiaAddressBook.Run();
            var motorolaGame = new HandsetMotorolaGame();
            motorolaGame.Run();
            var motorolaAddressBook = new HandsetMotorolaAddressBook();
            motorolaAddressBook.Run();
            Console.WriteLine("----");
            var game = new HandsetNokia(new Game());
            game.Run();
            var addressBook = new HandsetNokia(new AddressBook());
            addressBook.Run();
            var mGame = new HandsetMotorola(new Game());
            mGame.Run();
            var mAddressBook = new HandsetMotorola(new AddressBook());
            mAddressBook.Run();
        }

    }
}