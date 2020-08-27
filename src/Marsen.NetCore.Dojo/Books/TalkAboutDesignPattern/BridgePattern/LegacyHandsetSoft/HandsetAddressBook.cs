using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft
{
    public class HandsetAddressBook : HandsetSoft
    {
        public readonly SystemConsole Console = new SystemConsole();

        public override void Run(string brand)
        {
            Console.WriteLine($"Run {brand} Address Book");
        }
    }
}