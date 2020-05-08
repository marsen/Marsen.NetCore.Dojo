using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime FirstDay()
        {
            return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
        }

        public DateTime EndDay()
        {
            return DateTime.ParseExact(YearMonth + DateTime.DaysInMonth(FirstDay().Year,FirstDay().Month), "yyyyMMdd", null);
        }

        public int OverlapDays(Period period)
        {
            if (period.End < FirstDay() || EndDay() < period.Start)
            {
                return 0;
            }

            var overlapStartDay = FirstDay() < period.Start ? period.Start : FirstDay();
            var overlapEndDay = EndDay() < period.End ? EndDay() : period.End;
            return (overlapEndDay - overlapStartDay).Days + 1;
        }
    }
}