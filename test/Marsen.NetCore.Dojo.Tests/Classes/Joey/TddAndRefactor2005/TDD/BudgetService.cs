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
                var period = new Period(start, end);
                var budget = budgets.First();
                if (period.End<budget.FirstDay() || budget.EndDay()<period.Start)
                {
                    return 0;
                }

                return 1 * OverlapDays(budget, period);
            }
            return 0;
        }

        private static int OverlapDays(Budget budget, Period period)
        {
            var overlapStartDay = budget.FirstDay() < period.Start ? period.Start : budget.FirstDay();
            var overlapEndDay = budget.EndDay() < period.End ? budget.EndDay() : period.End;
            return (overlapEndDay - overlapStartDay).Days + 1;
        }
    }
}