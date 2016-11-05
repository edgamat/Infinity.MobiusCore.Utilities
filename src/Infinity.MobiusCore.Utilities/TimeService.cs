using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinity.MobiusCore.Utilities
{
    /// <summary>
    /// TimeService to replace calls to DateTime static methods.
    /// </summary>
    public class TimeService
    {
        /// <summary>
        /// The current provider.
        /// </summary>
        private static ITimeProvider current;

        /// <summary>
        /// Initializes static members of the <see cref="TimeService"/> class.
        /// </summary>
        static TimeService()
        {
            TimeService.ResetToDefault();
        }

        /// <summary>
        /// Gets or sets the current provider.
        /// </summary>
        public static ITimeProvider Current
        {
            get
            {
                return TimeService.current;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                TimeService.current = value;
            }
        }

        /// <summary>
        /// Resets to the default provider.
        /// </summary>
        public static void ResetToDefault()
        {
            TimeService.current = new DefaultTimeProvider();
        }
    }
}
