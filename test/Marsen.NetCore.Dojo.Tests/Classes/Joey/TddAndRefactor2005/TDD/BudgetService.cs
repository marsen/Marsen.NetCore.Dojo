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
            var period = new Period(start, end);
            decimal result = 0m;
            foreach (var b in budgets)
            {
                result += b.GetAmount(period);
            }

            return result;
        }
    }
}