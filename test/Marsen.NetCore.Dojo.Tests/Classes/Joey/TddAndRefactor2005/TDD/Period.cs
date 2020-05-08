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
    }
}