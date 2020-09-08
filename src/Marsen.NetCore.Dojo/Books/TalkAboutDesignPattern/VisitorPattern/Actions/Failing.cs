using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions
{
    public class Failing : Action
    {
        private const string Name = "失敗";

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