using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Tests")]

namespace Marsen.NetCore.TestingToolkit
{
    public struct SystemDateTime
    {
        private static DateTime? _mockDateTime = null;

        public static DateTime Now
        {
            get => _mockDateTime ?? DateTime.Now;
            internal set => _mockDateTime = value;
        }
    }
}