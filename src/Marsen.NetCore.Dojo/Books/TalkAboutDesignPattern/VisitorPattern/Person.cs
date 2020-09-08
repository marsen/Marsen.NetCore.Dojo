namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public abstract class Person
    {
        public abstract void Accept(Action visitor);
        public abstract string Name { get; }
    }
}