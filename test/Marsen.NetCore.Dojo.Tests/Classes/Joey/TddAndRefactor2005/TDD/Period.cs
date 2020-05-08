using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class Period
    {
        public Period(string start, string end)
        {
            Start = DateTime.ParseExact(start, "yyyyMMdd", null);
            EndDate = DateTime.ParseExact(end, "yyyyMMdd", null);
        }

        public string End { get; private set; }
        public DateTime Start { get; set; }
        public DateTime EndDate { get; set; }

        public int Days()
        {
            return (Start - EndDate).Days + 1;
        }
    }
}