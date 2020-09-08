using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public class Failing : Action
    {
        private const string Name = "失敗";
        public readonly SystemConsole Console = new SystemConsole();

        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{Name}時，悶頭喝酒，誰也不用勸");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{Name}時，眼淚汪汪，誰也勸不了");
        }
    }
}