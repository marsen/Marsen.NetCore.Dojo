using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.TDD;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    internal static class BudgetServiceTestsExtenstion
    {
        public static (BudgetService service, string start) Between(this BudgetService service,string start)
        {
            return (service, start);
        }
        public static (BudgetService service, string start, string end) And(this (BudgetService service,string start) target,string end)
        {
            return (target.service, target.start, end);
        }
        
        public static void ShouldBe(this (BudgetService service,string start,string end) target,int expected)
        {
            var actual = target.service.Query(target.start, target.end);
            Assert.Equal(expected,actual);
        }
    }
}