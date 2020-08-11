using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft.Refactored;

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
            var game = new HandsetNokia(new HandsetGame());
            game.Run();
            var addressBook = new HandsetNokia(new HandsetAddressBook());
            addressBook.Run();
            var mGame = new HandsetMotorola(new HandsetGame());
            mGame.Run();
            var mAddressBook = new HandsetMotorola(new HandsetAddressBook());
            mAddressBook.Run();
        }

    }
}