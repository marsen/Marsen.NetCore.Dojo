using System.Linq;
using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.TDD;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetServiceTests
    {
        private readonly IBudgetRepo _budgetRepo = Substitute.For<IBudgetRepo>();
        private BudgetService _budgetService;

        [Fact]
        public void NoBudget()
        {
            GiveBudgetIs();
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(0);
        }

        [Fact]
        public void PeriodInBudgetMonth()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200401").And("20200401").ShouldBe(1);
        }

        [Fact]
        public void PeriodBeforeBudgetMonth()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200310").And("20200320").ShouldBe(0);
        }

        [Fact]
        public void PeriodAfterBudgetMonth()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200510").And("20200520").ShouldBe(0);
        }


        [Fact]
        public void PeriodOverlapBudgetMonthFirstDay()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200331").And("20200402").ShouldBe(2);
        }

        [Fact]
        public void PeriodOverlapBudgetMonthLastDay()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200428").And("20200502").ShouldBe(3);
        }

        [Fact]
        public void PeriodOverlapBudgetAllMonth()
        {
            GiveBudgetIs(new Budget { YearMonth = "202004", Amount = 30 });
            BudgetAmount().Between("20200328").And("20200502").ShouldBe(30);
        }

        [Fact]
        public void MultipleBudgets()
        {
            GiveBudgetIs(
                new Budget { YearMonth = "202003", Amount = 310 },
                new Budget { YearMonth = "202004", Amount = 30 },
                new Budget { YearMonth = "202005", Amount = 3100 }
            );
            BudgetAmount().Between("20200328").And("20200502").ShouldBe(40 + 30 + 200);
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