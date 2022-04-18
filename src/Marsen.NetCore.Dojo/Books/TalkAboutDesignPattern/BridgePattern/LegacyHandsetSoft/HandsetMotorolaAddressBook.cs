using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft;

public class HandsetMotorolaAddressBook
{
    public readonly SystemConsole Console = new();

    public void Run()
    {
        Console.WriteLine("Run Motorola Address Book");
    }
}