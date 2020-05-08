using System;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.TDD
{
    public class Period
    {
        public Period(string start, string end)
        {
            Start = DateTime.ParseExact(start, "yyyyMMdd", null);
            End = DateTime.ParseExact(end, "yyyyMMdd", null);
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}