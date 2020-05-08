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
    }
}