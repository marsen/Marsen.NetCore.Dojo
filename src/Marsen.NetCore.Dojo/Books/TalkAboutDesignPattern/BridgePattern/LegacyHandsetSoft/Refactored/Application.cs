using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public abstract class Application
    {
        public readonly SystemConsole Console = new SystemConsole();

        public virtual void Run(string brand)
        {
        }
    }
}