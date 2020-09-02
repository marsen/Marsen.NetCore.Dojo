using System;
using System.Collections.Generic;
using Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Bridge;

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
            var man = new Man();
            man.Status = "成功";
            Console.WriteLine($"男人{man.Status}時，{man.GetConclusion()}");
            Console.WriteLine("女人成功時，背後多半有一個不成功的男人");
            var man2 = new Man();
            man2.Status = "失敗";
            Console.WriteLine($"男人{man2.Status}時，{man2.GetConclusion()}");
            // Console.WriteLine($"男人{man2.Status}時，悶頭喝酒，誰也不用勸");
            Console.WriteLine("女人失敗時，眼淚汪汪，誰也勸不了");
            var man3 = new Man();
            man3.Status = "戀愛";
            Console.WriteLine("男人戀愛時，凡事不懂也要裝懂");
            Console.WriteLine("女人戀愛時，遇事懂也裝作不懂");
        }
    }

    internal class Man
    {
        Dictionary<string, string> StatusLookup = new Dictionary<string, string> {
            {
                "成功","背後多半有一個偉大的女人"
            }
        };

        public string Status { get; set; }

        public string GetConclusion()
        {
            return StatusLookup[Status];
        }
    }
}