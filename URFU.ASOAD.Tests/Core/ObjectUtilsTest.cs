using System;
using System.Collections.Generic;

using NUnit.Framework;

using URFU.ASOAD.Core;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests.Core
{
    [TestFixture]
    public class ObjectUtilsTest
    {
        private const string TEST_STRING = "какой-то текст";

        private const string TEST_METHOD_NAME = "TestExtractMethodName";

        [Test]
        public void TestSerializeAndDeserialize()
        {
            SortedDictionary<string, Questionary> repository = new SortedDictionary<string, Questionary>();
            string key = Guid.NewGuid().ToString();
            repository.Add(key, new Questionary { AdditionalInfo = TEST_STRING });
            byte[] serialize = ObjectUtils.Serialize(repository);
            Assert.NotNull(serialize);

            repository = ObjectUtils.Deserialize<SortedDictionary<string, Questionary>>(serialize);
            Assert.AreEqual(1, repository.Count);
            Assert.IsTrue(repository.ContainsKey(key));
            Assert.AreEqual(TEST_STRING, repository[key].AdditionalInfo);
        }

        [Test]
        public void TestExtractMethodName()
        {
            Assert.AreEqual(TEST_METHOD_NAME, CallCallerMethodName());
        }

        private string CallCallerMethodName()
        {
            return ObjectUtils.CallerMethodName();
        }
    }
}
