using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft;

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

        public class HandsetNokia
        {
            private readonly HandsetSoft _soft;
            private string brand = "Nokia";
            public HandsetNokia(HandsetSoft soft)
            {
                _soft = soft;
            }

            public void Run()
            {
                this._soft.Run(brand);
            }
        }

        public class HandsetMotorola
        {
            private readonly HandsetSoft _soft;
            private string brand = "Motorola";

            public HandsetMotorola(HandsetSoft soft)
            {
                _soft = soft;
            }

            public void Run()
            {
                this._soft.Run(brand);
            }
        }
    }
}