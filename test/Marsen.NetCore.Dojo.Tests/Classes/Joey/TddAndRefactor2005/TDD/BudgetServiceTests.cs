using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetServiceTests
    {
        [Fact]
        public void NoBudget()
        {
            var budgetService = new BudgetService();
             Assert.Equal(0,budgetService.Query("20200401","20200401"));
        }
    }
}

