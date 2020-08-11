using System;
using System.Text;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class HandsetNokia : HandsetBrand
    {
        private readonly HandsetApp _app;

        public HandsetNokia(HandsetApp app)
        {
            _app = app;
        }
        public override void Run()
        {
            _app.Run();
        }
    }

    public abstract class HandsetApp
    {
        protected string _band;

        protected HandsetApp(string band)
        {
            _band = band;
        }
        public abstract void Run();
    }

    public class HandsetAddressBook : HandsetApp
    {
        public override void Run()
        {
            Console.WriteLine($"Run {_band} AddressBook");
        }

        public HandsetAddressBook(string band) : base(band)
        {
        }
    }


    public class HandsetGame : HandsetApp
    {
        public override void Run()
        {
            Console.WriteLine($"Run {_band} Game");
        }

        public HandsetGame(string band) : base(band)
        {
        }
    }
}