using System;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft
{
    public class AddressBook : Application
    {
        public override void Run(string band)
        {
            Console.WriteLine($"Run {band} Address Book");
        }

        internal readonly SystemConsole Console = new SystemConsole();
    }
}