using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Stamp.Net
{
    /// <summary>
    /// An implementation of a format provider which formats <see cref="DateTime"/> objects by example.
    /// </summary>
    public class DateTimeExampleFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType"/>, if the <see cref="T:System.IFormatProvider"/> implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(DateTimeFormatInfo))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg"/>, formatted as specified by <paramref name="format"/> and <paramref name="formatProvider"/>.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(DateTime))
            {
                try
                {
                    // handle formatting of every type which is not DateTime
                    return this.HandleOtherFormats(format, arg);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), ex);
                }
            }
            else
            {
                return this.FormatDateByExample(format, arg, formatProvider);
            }
        }

        private string FormatDateByExample(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(DateTime))
            {
                throw new ArgumentException("The argument should be of type DateTime", "arg");
            }
            DateTime dateToFormat = (DateTime)arg;

            Regex exampleFormat = new Regex(format);
            if (exampleFormat.IsMatch(DateTimeExampleFormatter.ExampleDateFormat1))
            {
                return dateToFormat.ToString("MMM dd, YY");
            }
            else
            {
                throw new FormatException(String.Format("The format '{0}' is invalid", format));
            }
        }

        /// <summary>
        /// Handles cases where the passed object that has to be formatted is not an instance of <see cref="DateTime"/>
        /// This is needed because of the way formatters are implemented in .NET. The method calles the respective type's formatting methods.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The arg.</param>
        /// <returns></returns>
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        private const string ExampleDateFormat1 = @"^(?<Month>September|January|February|March|April|June|July|August|October|November|December)\s(?<Day>[0-9][0-9]*),\s(?<Year>[0-9][0-9]([0-9][0-9]))$";
    }
}
