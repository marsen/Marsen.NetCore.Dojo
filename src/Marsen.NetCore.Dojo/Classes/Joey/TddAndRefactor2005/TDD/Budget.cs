using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.TDD;

public class Budget
{
    public string YearMonth { get; set; }
    public int Amount { get; set; }

    private DateTime FirstDay()
    {
        return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
    }

    private DateTime EndDay()
    {
        return DateTime.ParseExact(YearMonth + DaysInMonth(), "yyyyMMdd",
            null);
    }

    private int DaysInMonth()
    {
        return DateTime.DaysInMonth(FirstDay().Year, FirstDay().Month);
    }

    private int OverlapDays(Period period)
    {
        return IsOverlap(period) ? Days(period) : 0;
    }

    private int Days(Period period)
    {
        var overlapStartDay = FirstDay() < period.Start ? period.Start : FirstDay();
        var overlapEndDay = EndDay() < period.End ? EndDay() : period.End;
        return (overlapEndDay - overlapStartDay).Days + 1;
    }

    private bool IsOverlap(Period period)
    {
        return period.End >= FirstDay() && EndDay() >= period.Start;
    }

    public int GetAmount(Period period)
    {
        var dailyAmount = Amount / DaysInMonth();
        return dailyAmount * OverlapDays(period);
    }
}