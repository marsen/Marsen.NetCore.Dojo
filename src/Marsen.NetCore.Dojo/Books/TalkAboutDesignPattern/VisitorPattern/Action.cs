namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public abstract class Action
    {
        public abstract void GetManConclusion(Man man);
        public abstract void GetWomanConclusion(Woman woman);
    }
}