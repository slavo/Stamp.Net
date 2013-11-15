using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Stamp.Net.Tests
{
    [TestFixture]
    public class DateTimeExampleFormatterTest
    {
        [Test]
        public void GetFormat_WithDateTimeFormatInfo_ReturnsObject()
        {
            var formatter = new DateTimeExampleFormatter();
            var format = formatter.GetFormat(typeof(DateTimeFormatInfo));

            Assert.AreEqual(format, formatter);
        }

        [Test]
        public void GetFormat_WithRandomType_ReturnsNull()
        {
            var formatter = new DateTimeExampleFormatter();
            var format = formatter.GetFormat(typeof(string));

            Assert.IsNull(format);
        }
    }
}
