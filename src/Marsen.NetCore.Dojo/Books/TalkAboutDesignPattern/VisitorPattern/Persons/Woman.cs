using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

public class Woman : Person
{
    public override string Name => "女人";

    public override void Accept(Action visitor)
    {
        visitor.GetWomanConclusion(this);
    }
}