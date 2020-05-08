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

        public int Query(string start, string end)
        {
            var budgets = _budgetRepo.GetAll();
            if (budgets.Any())
            {
                var startDate = DateTime.ParseExact(start,"yyyyMMdd",null);
                var endDate = DateTime.ParseExact(end,"yyyyMMdd",null);
                return (startDate-endDate).Days+1;
            }
            return 0;
        }
    }
}