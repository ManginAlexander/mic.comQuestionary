using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;
using URFU.ASOAD.Server.Handlers;

namespace URFU.ASOAD.Tests.Server.Handlers
{
    [TestFixture]
    public class QuestionaryHandlerTest : BaseQuestionaryAccessTest
    {
        private IQuestionaryDao dao;

        private IQuestionaryHandler handler;

        public override void SetUp()
        {
            base.SetUp();
            dao = Mock.Of<IQuestionaryDao>();
            Mock<IQuestionaryDao> mock = Mock.Get(dao);
            mock.Setup(mockDao => mockDao.AllQuestionaries()).Returns(ReadAllQuestionaries);
            mock.Setup(mockDao => mockDao.Add(It.IsAny<Questionary>())).Callback<Questionary>(AddQuestionary);
            mock.Setup(mockDao => mockDao.Change(It.IsAny<Questionary>())).Callback<Questionary>(ChangeQuestionary);
            handler = new QuestionaryHandler { Dao = dao };
        }

        [Test]
        public void TestAddQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            handler.Add(questionary);
            Assert.AreEqual(1, TestQuestionaries.Count);
            Assert.IsTrue(ReferenceEquals(questionary, TestQuestionaries[0]));
        }

        [Test]
        public void TestHandleException()
        {
            Mock.Get(dao).Setup(mockDao => mockDao.Add(It.IsAny<Questionary>())).Throws<NotImplementedException>();
            Assert.Catch(typeof(HandleException), () => handler.Add(TestObjectsFactory.CreateQuestionary()));
        }

        [Test]
        public void TestAllQuestionaries()
        {
            Assert.IsEmpty(handler.AllQuestionaries());
            handler.Add(TestObjectsFactory.CreateQuestionary());
            handler.Add(TestObjectsFactory.CreateQuestionary());
            List<Questionary> allQuestionaries = handler.AllQuestionaries();
            Assert.IsNotEmpty(allQuestionaries);
            Assert.AreEqual(2, allQuestionaries.Count);
        }

        [Test]
        public void TestChangeQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            handler.Add(questionary);
            Assert.AreEqual(1, TestQuestionaries.Count);
            questionary.AdditionalInfo = Guid.NewGuid().ToString();
            handler.Change(questionary);
            Assert.AreEqual(1, TestQuestionaries.Count);
            Assert.AreEqual(questionary.AdditionalInfo, TestQuestionaries.First().AdditionalInfo);
        }

        [Test]
        public void TestAddInvalidQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            questionary.Person.FirstName = string.Empty;
            ValidationException validationException = Assert.Throws<ValidationException>(() => handler.Add(questionary));
            Assert.AreEqual(ErrorCode.ValidationError, validationException.ErrorCode);
        }
    }
}
