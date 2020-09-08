using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public class FallInLove : Action
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
}