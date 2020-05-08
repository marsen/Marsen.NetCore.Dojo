using System;

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
}