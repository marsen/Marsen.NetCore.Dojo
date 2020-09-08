using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.E2E.Tests
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("男人成功時，背後多半有一個偉大的女人");
            Console.WriteLine("女人成功時，背後多半有一個不成功的男人");
            Console.WriteLine("男人失敗時，悶頭喝酒，誰也不用勸");
            Console.WriteLine("女人失敗時，眼淚汪汪，誰也勸不了");
            Console.WriteLine("男人戀愛時，凡事不懂也要裝懂");
            Console.WriteLine("女人戀愛時，遇事懂也裝作不懂");
            Console.WriteLine("-----");
            Person man = new Man();
            Person woman = new Woman();
            man.Accept(new Success());
            woman.Accept(new Success());
            man.Accept(new Failing());
            woman.Accept(new Failing());
            man.Accept(new Amativeness());
            woman.Accept(new Amativeness());
        }
    }

    internal class Amativeness : Action
    {
        private string _name ="戀愛";
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{_name}時，凡事不懂也要裝懂");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{_name}時，遇事懂也裝作不懂");
        }
    }

    internal class Failing : Action
    {
        private string _name="失敗";

        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{_name}時，悶頭喝酒，誰也不用勸");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{_name}時，眼淚汪汪，誰也勸不了");
        }
    }

    abstract class Action
    {
        public abstract void GetManConclusion(Man man);
        public abstract void GetWomanConclusion(Woman woman);
    }
    internal class Success:Action
    {
        private string _name = "成功";

        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{_name}時，背後多半有一個偉大的女人");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{_name}時，背後多半有一個不成功的男人");
        }
    }
    

    internal class Woman : Person
    {
        public override void Accept(Action visitor)
        {
           visitor.GetWomanConclusion(this); 
        }

        public override string Name => "女人";

        protected override Dictionary<string, string> StatusLookup =>
            new Dictionary<string, string>
            {
                {"成功", "背後多半有一個不成功的男人"},
                {"失敗", "眼淚汪汪，誰也勸不了"},
                {"戀愛", "遇事懂也裝作不懂"},
            };
        public override string GetConclusion()
        {
            return StatusLookup[Action];
        }
    }

    internal abstract class Person
    {
        public abstract void Accept(Action visitor);
        public abstract string Name { get; }
        protected abstract Dictionary<string, string> StatusLookup { get; }
        public string Action { get; set; }

        public abstract string GetConclusion();
    }

    internal class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }

        public override string Name => "男人";

        protected override Dictionary<string, string> StatusLookup =>
            new Dictionary<string, string>
            {
                {"成功", "背後多半有一個偉大的女人"},
                {"失敗", "悶頭喝酒，誰也不用勸"},
                {"戀愛", "凡事不懂也要裝懂"},
            };
        
        public override string GetConclusion()
        {
            return StatusLookup[Action];
        }
    }
}