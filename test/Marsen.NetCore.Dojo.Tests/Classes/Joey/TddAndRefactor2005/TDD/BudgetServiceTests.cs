using System;
using System.Collections.Generic;
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
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(0);
        }

        [Fact]
        public void PeriodInBudgetMonth()
        {
            _budgetRepo.GetAll().Returns(new List<Budget> {new Budget {YearMonth = "202004",Amount=30}});
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(1);
        }

        private BudgetService BudgetAmount()
        {
            _budgetService = new BudgetService();
            return _budgetService;
        }
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }
    }

    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }
}