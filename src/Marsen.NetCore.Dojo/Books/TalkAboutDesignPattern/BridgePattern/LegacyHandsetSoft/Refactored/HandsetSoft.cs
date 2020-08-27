using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public abstract class HandsetSoft
    {
        public readonly SystemConsole Console = new SystemConsole();

        public virtual void Run(string brand)
        {
        }
    }
}