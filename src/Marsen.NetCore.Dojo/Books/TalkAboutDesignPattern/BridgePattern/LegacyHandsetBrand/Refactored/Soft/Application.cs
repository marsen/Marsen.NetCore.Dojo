using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft
{
    public abstract class Application
    {
        public readonly SystemConsole Console = new();
        public abstract void Run(string band);
    }
}