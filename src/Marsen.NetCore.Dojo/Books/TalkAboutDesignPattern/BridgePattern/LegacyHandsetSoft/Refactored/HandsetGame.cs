namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.BridgePattern.LegacyHandsetSoft.Refactored
{
    public class HandsetGame : HandsetSoft
    {
        public override void Run(string brand)
        {
            Console.WriteLine($"Run {brand} Game");
        }
    }
}