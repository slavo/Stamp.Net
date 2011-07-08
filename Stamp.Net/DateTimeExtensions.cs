using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

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
            return dateTime.ToStringExtended(example, new DateTimeExampleFormatter());
        }

        /// <summary>
        /// An alternative for the ToString() method of DateTime to work around a problem with implementing custom formatters for DateTime objects
        /// The default implementation, even if given a good IFormatProvider implementation, would never call a custom formatter. It would
        /// still use the default formatter.
        /// </summary>
        /// <param name="dateTime">The date time object.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string ToStringExtended(this DateTime dateTime, string format, IFormatProvider provider)
        {
            var formatter = provider.GetFormat(typeof(DateTimeFormatInfo)) as ICustomFormatter;
            if (formatter != null)
            {
                return formatter.Format(format, dateTime, provider);
            }
            throw new ArgumentException("The format provider argument did not return an instance that implements ICustomFormatter", "provider");
        }
    }
}
