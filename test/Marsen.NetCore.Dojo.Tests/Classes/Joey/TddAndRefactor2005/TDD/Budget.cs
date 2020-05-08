using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
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
            if (period.End < FirstDay() || EndDay() < period.Start)
            {
                return 0;
            }

            var overlapStartDay = FirstDay() < period.Start ? period.Start : FirstDay();
            var overlapEndDay = EndDay() < period.End ? EndDay() : period.End;
            return (overlapEndDay - overlapStartDay).Days + 1;
        }

        public int GetAmount(Period period)
        {
            var dailyAmount = Amount / DaysInMonth();
            return dailyAmount * OverlapDays(period);
        }
    }
}