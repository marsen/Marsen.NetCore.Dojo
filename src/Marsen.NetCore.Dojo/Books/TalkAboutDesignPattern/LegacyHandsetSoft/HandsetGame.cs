using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetSoft
{
    public class HandsetGame : HandsetSoft
    {
        public override void Run(string brand)
        {
            Console.WriteLine($"Run {brand} Game"); 
        }
    }
}