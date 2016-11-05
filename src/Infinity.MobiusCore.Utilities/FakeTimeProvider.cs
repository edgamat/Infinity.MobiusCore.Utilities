using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinity.MobiusCore.Utilities
{
    /// <summary>
    /// FakeTimeProvider Class.
    /// </summary>
    public class FakeTimeProvider : ITimeProvider
    {
        /// <summary>
        /// The offset
        /// </summary>
        private readonly TimeSpan _offset = TimeSpan.Zero;

        /// <summary>
        /// The time multiplier (in order to time travel)
        /// </summary>
        private readonly double _seemsLikeSeconds = 1;

        /// <summary>
        /// The time to start
        /// </summary>
        private DateTime _timeToStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeTimeProvider" /> class.
        /// </summary>
        /// <param name="timeToStart">The time to start.</param>
        public FakeTimeProvider(DateTime timeToStart)
            : this(timeToStart, false, TimeSpan.FromSeconds(1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeTimeProvider" /> class.
        /// </summary>
        /// <param name="timeToStart">The time to start.</param>
        /// <param name="useFixedTime">if set to <c>true</c> to use fixed time.</param>
        public FakeTimeProvider(DateTime timeToStart, bool useFixedTime)
            : this(timeToStart, useFixedTime, TimeSpan.FromSeconds(1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeTimeProvider" /> class.
        /// </summary>
        /// <param name="timeToStart">The time to start.</param>
        /// <param name="useFixedTime">if set to <c>true</c> to use fixed time.</param>
        /// <param name="secondsSeemLike">The seconds seem like multiplier.</param>
        public FakeTimeProvider(DateTime timeToStart, bool useFixedTime, TimeSpan secondsSeemLike)
        {
            this.SetStartTime(timeToStart);

            this.UseFixedTime = useFixedTime;

            this._offset = this._timeToStart - DateTime.UtcNow;

            this._seemsLikeSeconds = secondsSeemLike.TotalSeconds;
        }

        /// <summary>
        /// Gets a value indicating whether [use fixed time].
        /// </summary>
        public bool UseFixedTime { get; private set; }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UtcNow
        {
            get
            {
                if (this.UseFixedTime)
                {
                    return this._timeToStart;
                }

                // How many seconds does it seem like?
                var seemsLike = this.GetSeemsLikeSeconds();

                // Return the date/time that it seems like.
                var value = DateTime.UtcNow.AddSeconds(seemsLike);

                return value;
            }
        }

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on,
        /// expressed as the local time.
        /// </summary>
        public DateTime Now
        {
            get
            {
                if (this.UseFixedTime)
                {
                    return this._timeToStart;
                }

                // How many seconds does it seem like?
                var seemsLike = this.GetSeemsLikeSeconds();

                // Return the date/time that it seems like.
                var value = DateTime.Now.AddSeconds(seemsLike);

                return value;
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
                if (this.UseFixedTime)
                {
                    return this._timeToStart.Date;
                }

                // How many seconds does it seem like?
                var seemsLike = this.GetSeemsLikeSeconds();

                // Return the date/time that it seems like.
                var value = DateTime.Now.AddSeconds(seemsLike).Date;

                return value;
            }
        }

        /// <summary>
        /// Gets the seems like seconds.
        /// </summary>
        /// <returns>The number of seconds that have transpired in our fake world.</returns>
        private double GetSeemsLikeSeconds()
        {
            // Get the offset time.
            var value = DateTime.UtcNow;

            // Determine how much time has transpired.
            var delta = this._timeToStart - value;

            // How many seconds does it seem like?
            var seemsLike = delta.TotalSeconds * this._seemsLikeSeconds;

            return seemsLike;
        }

        /// <summary>
        /// Sets the start time.
        /// </summary>
        /// <param name="timeToStart">The time to start.</param>
        private void SetStartTime(DateTime timeToStart)
        {
            if (timeToStart.Kind == DateTimeKind.Utc)
            {
                this._timeToStart = timeToStart;
            }
            else
            {
                this._timeToStart = timeToStart.ToUniversalTime();
            }
        }
    }
}
