using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.LegacyHandsetBrand
{
    public class LegacyHandsetBrandTests
    {
        [Fact]
        public void Run()
        {
            HandsetMotorolaAddressBook target = new HandsetMotorolaAddressBook();
            target.Run();
            Assert.Equal("Run Motorola Address Book",target.Console.Message); 
            Assert.Equal(1,target.Console.WriteLineTimes);
        } 
        
    }
}