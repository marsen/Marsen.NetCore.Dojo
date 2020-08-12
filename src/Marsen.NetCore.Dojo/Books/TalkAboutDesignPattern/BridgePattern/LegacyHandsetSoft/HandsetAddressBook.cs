using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft
{
    public class HandsetAddressBook : HandsetSoft
    {
        public override void Run(string brand)
        {
            Console.WriteLine($"Run {brand} Address Book"); 
        }
    }
}