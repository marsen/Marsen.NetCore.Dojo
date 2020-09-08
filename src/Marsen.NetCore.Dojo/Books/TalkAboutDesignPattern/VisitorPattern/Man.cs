using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public class Man : Person
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