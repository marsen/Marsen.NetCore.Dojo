using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetService
    {
        private readonly IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal Query(string start, string end)
        {
            var budgets = _budgetRepo.GetAll();
            // if (budgets.Any())
            {
                var period = new Period(start, end);
                return budgets.Aggregate(0m, (current, b) => current + b.GetAmount(period));
            }

            return 0;
        }
    }
}