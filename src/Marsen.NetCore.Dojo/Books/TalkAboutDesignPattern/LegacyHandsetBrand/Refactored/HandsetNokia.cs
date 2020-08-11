using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand.Refactored
{
    public class HandsetNokia : HandsetBrand
    {
        public HandsetNokia(HandsetApp app):base(app)
        {
            Band = "Nokia";
        }
        public override void Run()
        {
            this.App.Run(Band);
        }
    }

    public abstract class HandsetApp
    {
        public abstract void Run(string band);
    }

    public class HandsetAddressBook : HandsetApp
    {
        public override void Run(string band)
        {
            Console.WriteLine($"Run {band} Address Book");
        }
    }


    public class HandsetGame : HandsetApp
    {
        public override void Run(string band)
        {
            Console.WriteLine($"Run {band} Game");
        }

    }
}