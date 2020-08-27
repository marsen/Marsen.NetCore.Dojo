using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Tests")]
[assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Integration.Tests")]

namespace Marsen.NetCore.TestingToolkit
{
    public class SystemConsole
    {
        public void WriteLine(string message)
        {
            Message = message;
            WriteLineTimes++;
            Console.WriteLine(message);
        }

        internal int WriteLineTimes { get; private set; }

        internal string Message { get; private set; }
    }
}