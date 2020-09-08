using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public abstract class Person
    {
        public abstract void Accept(Action visitor);
        public abstract string Name { get; }
        protected abstract Dictionary<string, string> StatusLookup { get; }
        public string Action { get; set; }

        public abstract string GetConclusion();
    }
}