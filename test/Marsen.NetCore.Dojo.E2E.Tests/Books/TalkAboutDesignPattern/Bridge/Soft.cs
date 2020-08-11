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

        public class HandsetNokia : HandsetBrand
        {
            public HandsetNokia(HandsetSoft soft)
            {
                _soft = soft;
                _brand = "Nokia";
            }

            public override void Run()
            {
                this._soft.Run(_brand);
            }
        }

        public abstract class HandsetBrand
        {
            protected HandsetSoft _soft;
            protected string _brand;
            public abstract void Run();
        }

        public class HandsetMotorola : HandsetBrand
        {
            public HandsetMotorola(HandsetSoft soft)
            {
                _soft = soft;
                _brand = "Motorola";
            }

            public override void Run()
            {
                this._soft.Run(_brand);
            }
        }
    }
}