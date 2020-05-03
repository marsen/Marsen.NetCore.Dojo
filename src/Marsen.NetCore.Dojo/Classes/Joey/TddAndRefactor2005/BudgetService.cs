using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005
{
    public class BudgetService
    {
        private IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal Query(DateTime start, DateTime end)
        {
            var budgets = _budgetRepo.GetAll();
            if (start > end)
                return 0;

            return GetBudget(start, end, budgets);
        }

        private decimal GetBudget(DateTime start, DateTime end, List<Budget> budgets)
        {

            var dayAmountDict = budgets.Select(x => new
            {
                YearMonth = x.YearMonth,
                DayAmount = x.Amount / DateTime.DaysInMonth(DateTime.ParseExact((string) x.YearMonth, "yyyyMM", null).Year, DateTime.ParseExact((string) x.YearMonth, "yyyyMM", null).Month)

            }).ToDictionary(x => x.YearMonth, y => y.DayAmount);


            if (end.Month - start.Month >= 1)
            {

                int startAmount = (DateTime.DaysInMonth(start.Year, start.Month) - start.Day + 1) * dayAmountDict[start.ToString("yyyyMM")];
                int endAmount = (end.Day) * dayAmountDict[end.ToString("yyyyMM")];

                return startAmount + endAmount;
            }
            else
            {
                int totoalDay = (end - start).Days + 1;

                var amount = budgets
                    .Where(x => x.YearMonth == start.ToString("yyyyMM"))
                    .Sum(a => a.Amount);

                return amount / 30 * totoalDay;
            }

        }


        private Dictionary<string, int> GetDaysDict(DateTime start, DateTime end)
        {
            var diffM = end.Month - start.Month;
            var result = new Dictionary<string, int>();
            for (int i = 0; i < diffM + 1; i++)
            {
                var date = start.AddMonths(i);
                result.Add(date.ToString("yyyyMM"), DateTime.DaysInMonth(date.Year, date.Month));
            }

            return result;
        }
    }
}