using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

public class Man : Person
{
    public override string Name => "男人";

    public override void Accept(Action visitor)
    {
        visitor.GetManConclusion(this);
    }
}