using Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory;

namespace Marsen.NetCore.Dojo.E2E.Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            ClientA.Run();
            ClientB.Run();
            ClientC.Run();
        }
    }
}