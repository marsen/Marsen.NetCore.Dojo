using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions
{
    public abstract class Action
    {
        public readonly SystemConsole Console = new SystemConsole();
        public abstract void GetManConclusion(Man man);
        public abstract void GetWomanConclusion(Woman woman);
    }
}