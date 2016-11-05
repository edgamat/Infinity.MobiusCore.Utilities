using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinity.MobiusCore.Utilities
{
    /// <summary>
    /// DefaultTimeProvider class
    /// </summary>
    public class DefaultTimeProvider : ITimeProvider
    {
        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on,
        /// expressed as the local time.
        /// </summary>
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date on,
        /// expressed as the local time.
        /// </summary>
        public DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
