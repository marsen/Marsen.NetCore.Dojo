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

        public int Days()
        {
            var startDate = DateTime.ParseExact(Start, "yyyyMMdd", null);
            var endDate = DateTime.ParseExact(End, "yyyyMMdd", null);
            return (startDate - endDate).Days + 1;
        }
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
                var period = new Period(start, end);
                return period.Days();
            }
            return 0;
        }
    }
}