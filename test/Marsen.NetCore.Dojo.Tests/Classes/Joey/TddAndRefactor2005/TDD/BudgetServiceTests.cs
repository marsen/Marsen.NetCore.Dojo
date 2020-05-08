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
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(0);
        }

        private BudgetService BudgetAmount()
        {
            _budgetService = new BudgetService();
            return _budgetService;
        }
    }
}

