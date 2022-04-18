using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand
{
    public class HandsetNokiaAddressBook
    {
        internal readonly SystemConsole Console = new();

        public void Run()
        {
            Console.WriteLine("Run Nokia Address Book");
        }
    }
}