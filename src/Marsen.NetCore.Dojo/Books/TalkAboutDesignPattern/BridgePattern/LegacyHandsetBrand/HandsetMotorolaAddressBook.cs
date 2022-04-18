using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand;

public class HandsetMotorolaAddressBook
{
    internal readonly SystemConsole Console = new();

    public void Run()
    {
        Console.WriteLine("Run Motorola Address Book");
    }
}