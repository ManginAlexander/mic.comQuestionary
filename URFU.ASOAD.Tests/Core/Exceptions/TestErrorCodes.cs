using System;

using NUnit.Framework;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;

namespace URFU.ASOAD.Tests.Core.Exceptions
{
    [TestFixture]
    public class TestErrorCodes
    {
        [Test]
        public void AllErrorCodesHasMessageTest()
        {
            int index = -1;
            while (Enum.IsDefined(typeof(ErrorCode), ++index))
            {
                Assert.IsNotEmpty(ASOADException.GetMessage((ErrorCode)index, null));
            }
        }
    }
}
