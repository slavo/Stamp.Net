using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stamp.Net
{
    /// <summary>
    /// Contains extension methods for the <see cref="DateTime"/> class that can be used to format a date by example
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats the specified date time by using the example parameter's format.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="example">The example.</param>
        /// <returns>A string representation of the <see cref="DateTime"/> object</returns>
        public static string Format(this DateTime dateTime, string example)
        {
            return dateTime.ToString(example, new DateTimeExampleFormatter());
        }
    }
}
