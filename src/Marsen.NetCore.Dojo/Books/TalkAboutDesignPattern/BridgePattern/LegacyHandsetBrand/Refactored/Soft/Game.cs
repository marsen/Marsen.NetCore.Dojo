using System;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetBrand.Refactored.Soft
{
    public class Game : Application
    {
        internal readonly SystemConsole Console = new SystemConsole();

        public override void Run(string band)
        {
            Console.WriteLine($"Run {band} Game");
        }
    }
}