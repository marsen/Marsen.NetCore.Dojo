using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;

public class FallInLove : Action
{
    private const string Name = "戀愛";

    public override void GetManConclusion(Man man)
    {
        Console.WriteLine($"{man.Name}{Name}時，凡事不懂也要裝懂");
    }

    public override void GetWomanConclusion(Woman woman)
    {
        Console.WriteLine($"{woman.Name}{Name}時，遇事懂也裝作不懂");
    }
}