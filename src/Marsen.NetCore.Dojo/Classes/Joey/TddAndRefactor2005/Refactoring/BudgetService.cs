using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005;

public class BudgetService
{
    private readonly IBudgetRepo _budgetRepo;

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
            x.YearMonth,
            DayAmount = x.Amount / DateTime.DaysInMonth(DateTime.ParseExact(x.YearMonth, "yyyyMM", null).Year,
                DateTime.ParseExact(x.YearMonth, "yyyyMM", null).Month)
        }).ToDictionary(x => x.YearMonth, y => y.DayAmount);


        if (end.Month - start.Month >= 1)
        {
            var startAmount = (DateTime.DaysInMonth(start.Year, start.Month) - start.Day + 1) *
                              dayAmountDict[start.ToString("yyyyMM")];
            var endAmount = end.Day * dayAmountDict[end.ToString("yyyyMM")];

            return startAmount + endAmount;
        }

        var amount = budgets
            .Where(x => x.YearMonth == start.ToString("yyyyMM"))
            .Sum(a => a.Amount);

        return amount / DateTime.DaysInMonth(start.Year, start.Month) * ((end - start).Days + 1);
    }
}