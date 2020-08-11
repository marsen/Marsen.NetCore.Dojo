using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern
{
    public static class Startup
    {
        public static void Start()
        {
            var handsetNokiaAddressBook = new HandsetNokiaAddressBook();
            handsetNokiaAddressBook.Run();
            var handsetNokiaGame = new HandsetNokiaGame();
            handsetNokiaGame.Run();
            var handsetMotorolaAddressBook = new HandsetMotorolaAddressBook();
             handsetMotorolaAddressBook.Run();
            var handsetMotorolaGame = new HandsetMotorolaGame();
            handsetMotorolaGame.Run();
            Console.WriteLine("-----");
            var address = new HandsetNokia(new HandsetAddressBook());
            address.Run();
            var game = new HandsetNokia(new HandsetGame());
            game.Run();
            var mAddressBook = new HandsetMotorola(new HandsetAddressBook());
            mAddressBook.Run();
            var mGame = new HandsetMotorola(new HandsetGame());
            mGame.Run();
        }
    }
}