using System;
using System.Collections.Generic;
using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005
{
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;
        private FakeBudgetRepo _fakeRepo;

        public BudgetServiceTests()
        {
            _fakeRepo = new FakeBudgetRepo();
            _budgetService = new BudgetService(_fakeRepo);
        }

        [Fact()]
        public void April_OneDay()
        {
            _fakeRepo.SetBudgets(new List<Budget>()
            {
                new Budget()
                {
                    YearMonth = "202004",
                    Amount = 30000
                }
            });
            BudgetShouldBe(1000, new DateTime(2020, 04, 01), new DateTime(2020, 04, 01));
        }


        [Fact()]
        public void April_MultiDay()
        {
            _fakeRepo.SetBudgets(new List<Budget>()
            {
                new Budget()
                {
                    YearMonth = "202004",
                    Amount = 30000
                }
            });
            BudgetShouldBe(5000, new DateTime(2020, 04, 01), new DateTime(2020, 04, 05));
        }

        [Fact()]
        public void April_OneMonth()
        {
            _fakeRepo.SetBudgets(new List<Budget>()
            {
                new Budget()
                {
                    YearMonth = "202004",
                    Amount = 60000
                }
            });
            BudgetShouldBe(60000, new DateTime(2020, 04, 01), new DateTime(2020, 04, 30));
        }

        [Fact()]
        public void April_MultiMonth()
        {
            _fakeRepo.SetBudgets(new List<Budget>()
            {
                new Budget()
                {
                    YearMonth = "202002",
                    Amount = 2900
                },
                new Budget()
                {
                    YearMonth = "202003",
                    Amount = 310
                }
            });
            BudgetShouldBe(3050, new DateTime(2020, 02, 01), new DateTime(2020, 03, 15));
        }

        [Fact()]
        public void Reverse_Date()
        {
            _fakeRepo.SetBudgets(new List<Budget>()
            {
                new Budget()
                {
                    YearMonth = "202002",
                    Amount = 2900
                },
                new Budget()
                {
                    YearMonth = "202003",
                    Amount = 310
                }
            });
            BudgetShouldBe(0, new DateTime(2020, 03, 01), new DateTime(2020, 02, 01));
        }

        private void BudgetShouldBe(int expected, DateTime start, DateTime end)
        {
            Assert.Equal(expected, _budgetService.Query(start, end));
        }
    }

    public class FakeBudgetRepo : IBudgetRepo
    {
        private List<Budget> _budgetList;

        public void SetBudgets(List<Budget> budgets)
        {
            _budgetList = budgets;
        }

        public List<Budget> GetAll()
        {
            return _budgetList;
        }
    }
}