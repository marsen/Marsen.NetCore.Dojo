using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Brand;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Bridge
{
    public static class Brand
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
            var address = new HandsetNokia(new AddressBook());
            address.Run();
            var game = new HandsetNokia(new Game());
            game.Run();
            var mAddressBook = new HandsetMotorola(new AddressBook());
            mAddressBook.Run();
            var mGame = new HandsetMotorola(new Game());
            mGame.Run();
        }
    }
}