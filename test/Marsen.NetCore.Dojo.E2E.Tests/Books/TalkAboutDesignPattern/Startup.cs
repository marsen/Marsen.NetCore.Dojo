using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.LegacyHandsetBrand;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern
{
    public static class Startup
    {
        public static void Start()
        {
            var handsetNokiaAddressBook = new HandsetNokiaAddressBook();
            handsetNokiaAddressBook.Run();
            var handsetNokiaGame = new HandsetNokiaGame();
            handsetNokiaGame.Run();
            var handsetMotorolaAddressBook = new HandsetMotorolaAddressBook();
            handsetMotorolaAddressBook.Run();
            var handsetMotorolaGame = new HandsetMotorolaGame();
            handsetMotorolaGame.Run();
        }
    }
}