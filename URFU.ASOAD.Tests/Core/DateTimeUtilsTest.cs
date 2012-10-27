using System;

using NUnit.Framework;

using URFU.ASOAD.Core;

namespace URFU.ASOAD.Tests.Core
{
    [TestFixture]
    public class DateTimeUtilsTest
    {
        private const string TEST_DATE = "20.10.2012";
        private const string TEST_DATE_TIME = TEST_DATE + " 10:00:00";
        private const string TEST_DATE_TIME_MS = TEST_DATE_TIME + ".123";

        [Test]
        public void TestDateTimeToString()
        {
            DateTime dateTime = TestObjectsFactory.ToDate(TEST_DATE_TIME_MS);
            Assert.AreEqual(TEST_DATE, dateTime.ToFormatString(DateTimeUtils.Format.DateOnly));
            Assert.AreEqual(TEST_DATE_TIME, dateTime.ToFormatString(DateTimeUtils.Format.DateTime));
            Assert.AreEqual(TEST_DATE_TIME_MS, dateTime.ToFormatString());
        }
    }
}
