using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft
{
    public abstract class Application
    {
        public readonly SystemConsole Console = new SystemConsole();
        public abstract void Run(string band);
    }
}