using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand
{
    public class HandsetMotorolaAddressBook
    {
        
        public void Run()
        {
            SystemConsole.WriteLine("Run Motorola Address Book");
            // Console.WriteLine("Run Motorola Address Book");
        }
    }

    public static class SystemConsole
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}