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
                var dailyAmount = budget.Amount / DateTime.DaysInMonth( 
                    DateTime.ParseExact(budget.YearMonth + "01", "yyyyMMdd", null).Year,
                    DateTime.ParseExact(budget.YearMonth + "01", "yyyyMMdd", null).Month);
                return dailyAmount * OverlapDays(budget, period);
            }

            return 0;
        }

        private static int OverlapDays(Budget budget, Period period)
        {
            if (period.End < budget.FirstDay() || budget.EndDay() < period.Start)
            {
                return 0;
            }

            var overlapStartDay = budget.FirstDay() < period.Start ? period.Start : budget.FirstDay();
            var overlapEndDay = budget.EndDay() < period.End ? budget.EndDay() : period.End;
            return (overlapEndDay - overlapStartDay).Days + 1;
        }
    }
}