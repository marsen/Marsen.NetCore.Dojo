using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern
{
    public class VisitorPatternTests
    {
        [Fact]
        public void Success_GetManConclusion_Man()
        {
            var target = new Success();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("男人成功時，背後多半有一個偉大的女人", target.Console.Message);
        }

        [Fact]
        public void Success_GetWomanConclusion_Woman()
        {
            var target = new Success();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("女人成功時，背後多半有一個不成功的男人", target.Console.Message);
        }

        [Fact]
        public void Failing_GetWomanConclusion_Woman()
        {
            var target = new Failing();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("女人失敗時，眼淚汪汪，誰也勸不了", target.Console.Message);
        }

        [Fact]
        public void Failing_GetManConclusion_Man()
        {
            var target = new Failing();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("男人失敗時，悶頭喝酒，誰也不用勸", target.Console.Message);
        }

        [Fact]
        public void FallInLove_GetManConclusion_Man()
        {
            var target = new FallInLove();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("男人戀愛時，凡事不懂也要裝懂", target.Console.Message);
        }

        [Fact]
        public void FallInLove_GetWomanConclusion_Woman()
        {
            var target = new FallInLove();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
            Assert.Equal("女人戀愛時，遇事懂也裝作不懂", target.Console.Message);
        }

        [Fact]
        public void Man()
        {
            var target = new Man();
            var mockAction = new MockAction();
            target.Accept(mockAction);
            Assert.Equal(1, mockAction.ManActionCallTimes);
        }

        [Fact]
        public void Woman()
        {
            var target = new Woman();
            var mockAction = new MockAction();
            target.Accept(mockAction);
            Assert.Equal(1, mockAction.WomanActionCallTimes);
        }

        private class MockAction : Action
        {
            public override void GetManConclusion(Man man)
            {
                ManActionCallTimes++;
            }

            public override void GetWomanConclusion(Woman woman)
            {
                WomanActionCallTimes++;
            }

            public int ManActionCallTimes { get; private set; }
            public int WomanActionCallTimes { get; private set; }
        }
    }
}