using System;
using System.Text;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class HandsetNokia : HandsetBrand
    {
        public override void Run()
        {
            // var app = new HandsetGame("Nokia");
            var app = new HandsetAddressBook("Nokia");
            app.Run();
        }
    }

    public class HandsetAddressBook
    {
        private readonly string _band;

        public HandsetAddressBook(string band)
        {
            _band = band;
        }
        public void Run()
        {
            Console.WriteLine($"Run {_band} AddressBook");
        }
    }


    public class HandsetGame
    {
        private readonly string _band;

        public HandsetGame(string band)
        {
            _band = band;
        }

        public void Run()
        {
            Console.WriteLine($"Run {_band} Game");
        }

    }
}