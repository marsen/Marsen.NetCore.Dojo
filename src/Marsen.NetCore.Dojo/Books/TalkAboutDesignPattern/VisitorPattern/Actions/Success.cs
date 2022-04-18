using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;

public class Success : Action
{
    private const string Name = "成功";

    public override void GetManConclusion(Man man)
    {
        Console.WriteLine($"{man.Name}{Name}時，背後多半有一個偉大的女人");
    }

    public override void GetWomanConclusion(Woman woman)
    {
        Console.WriteLine($"{woman.Name}{Name}時，背後多半有一個不成功的男人");
    }
}