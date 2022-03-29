using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Tests")]

namespace Marsen.NetCore.TestingToolkit
{
    /// <summary>
    ///     SystemDateTime
    /// </summary>
    public struct SystemDateTime
    {
        /// <summary>
        ///     The mock date time
        /// </summary>
        private static DateTime? _mockDateTime;
        
        private static DateTime? _mockUtcDateTime;

        /// <summary>
        ///     Gets the now.
        /// </summary>
        /// <value>
        ///     The now.
        /// </value>
        public static DateTime Now
        {
            get => _mockDateTime ?? DateTime.Now;
            internal set => _mockDateTime = value;
        }
        
        public static DateTime UtcNow
        {
            get => _mockUtcDateTime ?? DateTime.UtcNow;
            internal set => _mockUtcDateTime = value;
        }

        /// <summary>
        ///     Resets this instance.
        /// </summary>
        internal static void Reset()
        {
            _mockDateTime = null;
            _mockUtcDateTime = null;
        }
    }
}