using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class Period
    {
        public Period(string start, string end)
        {
            Start = start;
            End = end;
        }

        public string Start { get; private set; }
        public string End { get; private set; }
    }

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
                return Days(new Period(start, end));
            }
            return 0;
        }

        private static int Days(Period period)
        {
            var startDate = DateTime.ParseExact(period.Start, "yyyyMMdd", null);
            var endDate = DateTime.ParseExact(period.End, "yyyyMMdd", null);
            return (startDate - endDate).Days + 1;
        }
    }
}