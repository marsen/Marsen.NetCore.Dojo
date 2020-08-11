using System;
using System.Text;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class HandsetNokia : HandsetBrand
    {
        public override void Run()
        {
            var game = new HandsetGame("Nokia");
            game.Run();
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