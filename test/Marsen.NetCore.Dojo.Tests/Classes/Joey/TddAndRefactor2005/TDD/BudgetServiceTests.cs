using System;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;
        private readonly IBudgetRepo _budgetRepo = Substitute.For<IBudgetRepo>();

        [Fact]
        public void NoBudget()
        {
            GiveBudgetIs();
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(0);
        }

        [Fact(Skip = "Maybe Not Now")]
        public void PeriodInBudgetMonth()
        {
            GiveBudgetIs(new Budget {YearMonth = "202004", Amount = 30});
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(1);
        }

        [Fact]
        public void PeriodBeforeBudgetMonth()
        {
            GiveBudgetIs(new Budget {YearMonth = "202004", Amount = 30});
            BudgetAmount().Between("20200310").And("20200320").ShouldBe(0);
        }


        [Fact(Skip = "Maybe Not Now")]
        public void LeftPeriodOverlapBudgetMonth()
        {
            GiveBudgetIs(new Budget {YearMonth = "202004", Amount = 30});
            BudgetAmount().Between("20200331").And("20200402").ShouldBe(2);
        }


        private void GiveBudgetIs(params Budget[] budgets)
        {
            _budgetRepo.GetAll().Returns(budgets.ToList());
        }

        private BudgetService BudgetAmount()
        {
            _budgetService = new BudgetService(_budgetRepo);
            return _budgetService;
        }
    }
}