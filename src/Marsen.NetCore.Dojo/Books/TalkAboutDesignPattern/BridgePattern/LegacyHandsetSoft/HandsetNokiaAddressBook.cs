using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft
{
    public class HandsetNokiaAddressBook
    {
        public readonly SystemConsole Console = new();

        public void Run()
        {
            Console.WriteLine("Run Nokia Address Book");
        }
    }
}