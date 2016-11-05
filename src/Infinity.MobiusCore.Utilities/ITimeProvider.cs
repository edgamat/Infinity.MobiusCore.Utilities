using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinity.MobiusCore.Utilities
{
    /// <summary>
    /// ITimeProvider Interface
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on,
        /// expressed as the local time.
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        DateTime UtcNow { get; }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date on,
        /// expressed as the local time.
        /// </summary>
        DateTime Today { get; }
    }
}
