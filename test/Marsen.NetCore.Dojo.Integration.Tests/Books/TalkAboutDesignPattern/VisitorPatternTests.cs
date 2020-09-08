using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern;
using Marsen.NetCore.TestingToolkit;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Books.TalkAboutDesignPattern
{
    public class VisitorPatternTests
    {
        [Fact]
        public void Success_GetManConclusion_Man()
        {
            var target = new Success();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void Success_GetWomanConclusion_Woman()
        {
            var target = new Success();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void Failing_GetWomanConclusion_Woman()
        {
            var target = new Failing();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void Failing_GetManConclusion_Man()
        {
            var target = new Failing();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void FallInLove_GetManConclusion_Man()
        {
            var target = new FallInLove();
            target.GetManConclusion(new Man());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }

        [Fact]
        public void FallInLove_GetWomanConclusion_Woman()
        {
            var target = new FallInLove();
            target.GetWomanConclusion(new Woman());
            Assert.Equal(1, target.Console.WriteLineTimes);
        }
    }
}