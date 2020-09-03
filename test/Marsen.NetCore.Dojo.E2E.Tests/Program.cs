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
            man.Status = "成功";
            Console.WriteLine($"{man.Name}{man.Status}時，{man.GetConclusion()}");
            Person woman = new Woman();
            woman.Status = "成功";
            Console.WriteLine($"{woman.Name}{woman.Status}時，{woman.GetConclusion()}");
            man.Status = "失敗";
            woman.Status = "失敗";
            Console.WriteLine($"{man.Name}{man.Status}時，{man.GetConclusion()}");
            Console.WriteLine($"{woman.Name}{woman.Status}時，{woman.GetConclusion()}");
            man.Status = "戀愛";
            woman.Status = "戀愛";
            Console.WriteLine($"{man.Name}{man.Status}時，{man.GetConclusion()}");
            Console.WriteLine($"{woman.Name}{woman.Status}時，{woman.GetConclusion()}");
        }
    }

    internal class Woman : Person
    {
        public override string Name =>"女人";

        protected override Dictionary<string, string> StatusLookup =>
            new Dictionary<string, string>
            {
                {"成功", "背後多半有一個不成功的男人"},
                {"失敗", "眼淚汪汪，誰也勸不了"},
                {"戀愛", "遇事懂也裝作不懂"},
            };
    }

    internal abstract class Person
    {
        public abstract string Name { get; }
        protected abstract Dictionary<string, string> StatusLookup { get; }
        public string Status { get; set; }

        public string GetConclusion()
        {
            return StatusLookup[Status];
        }
    }

    internal class Man : Person
    {
        public override string Name => "男人";

        protected override Dictionary<string, string> StatusLookup =>
            new Dictionary<string, string>
            {
                {"成功", "背後多半有一個偉大的女人"},
                {"失敗", "悶頭喝酒，誰也不用勸"},
                {"戀愛", "凡事不懂也要裝懂"},
            };
    }
}