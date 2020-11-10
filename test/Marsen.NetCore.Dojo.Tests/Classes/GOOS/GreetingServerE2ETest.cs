using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.GOOS
{
    public class GreetingServerE2ETest
    {
        [Fact]
        public void Should_Greet_With_Hello_World()
        {
            GreetingServer.main();
            
        }
    }

    public static class GreetingServer
    {
        public static void main(params string[] args)
        {
        }
    }
}