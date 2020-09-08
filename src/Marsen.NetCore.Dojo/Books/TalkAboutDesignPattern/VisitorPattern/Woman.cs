using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public class Woman : Person
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
}