using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Soft;

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
            var address = new Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand.HandsetNokia(new AddressBook());
            address.Run();
            var game = new Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored.Brand.HandsetNokia(new Game());
            game.Run();
            var mAddressBook = new HandsetMotorola(new AddressBook());
            mAddressBook.Run();
            var mGame = new HandsetMotorola(new Game());
            mGame.Run();
        }
    }
}