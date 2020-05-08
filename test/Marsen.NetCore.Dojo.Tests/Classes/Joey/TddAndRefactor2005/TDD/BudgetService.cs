using System;
using System.Collections.Generic;
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
            var period = new Period(start, end);
            decimal result = 0m;
            foreach (var b in _budgetRepo.GetAll())
            {
                result += b.GetAmount(period);
            }

            return result;
        }
    }
}