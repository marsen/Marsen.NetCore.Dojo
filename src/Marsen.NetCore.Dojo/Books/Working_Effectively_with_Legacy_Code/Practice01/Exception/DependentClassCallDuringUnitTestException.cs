using System;
using System.Runtime.Serialization;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception
{
    [Serializable]
    public class DependentClassCallDuringUnitTestException : System.Exception
    {
        public DependentClassCallDuringUnitTestException()
        {
        }

        public DependentClassCallDuringUnitTestException(string message, System.Exception innerException) : base(
            message, innerException)
        {
        }

        public DependentClassCallDuringUnitTestException(string message) : base(message)
        {
        }

        private DependentClassCallDuringUnitTestException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }
    }
}