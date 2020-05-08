using System;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.TDD
{
    public class Period
    {
        public Period(string start, string end)
        {
            Start = DateTime.ParseExact(start, "yyyyMMdd", null);
            End = DateTime.ParseExact(end, "yyyyMMdd", null);
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int Days()
        {
            return (Start - End).Days + 1;
        }
    }
}