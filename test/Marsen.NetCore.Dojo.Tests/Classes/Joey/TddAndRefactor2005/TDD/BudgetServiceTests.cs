using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;

        [Fact]
        public void NoBudget()
        {
            _budgetService = new BudgetService();
            Between("20200401").And("20200401").ShouldBe(0);
        }

        private (BudgetService target, string start) Between(string start)
        {
            return (_budgetService,start);
        }
    }
    internal static class BudgetServiceTestsExtenstion
    {
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

