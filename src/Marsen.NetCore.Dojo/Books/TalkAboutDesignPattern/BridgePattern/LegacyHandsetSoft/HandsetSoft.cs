using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft
{
    public class HandsetSoft
    {
        public readonly SystemConsole Console = new SystemConsole();

        public virtual void Run(string brand)
        {
        }
    }
}