using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests.Db.Dao
{
    [TestFixture]
    public class QuestionaryDaoTest : BaseQuestionaryAccessTest
    {
        private IQuestionaryRepository repository;

        private IQuestionaryDao dao;

        public override void SetUp()
        {
            base.SetUp();
            //другие интересные возможности синтаксиса Moq смотри здесь: http://sergeyteplyakov.blogspot.com/2012/09/moq.html
            //к сожалению, на первую инициализацию требуется время - но чем-то всегда приходится платить за удобство
            repository = Mock.Of<IQuestionaryRepository>();
            Mock<IQuestionaryRepository> mock = Mock.Get(repository);
            mock.Setup(mockDao => mockDao.AllQuestionaries()).Returns(ReadAllQuestionaries);
            mock.Setup(mockRepo => mockRepo.Add(It.IsAny<Questionary>())).Callback<Questionary>(AddQuestionary);
            mock.Setup(mockRepo => mockRepo.Change(It.IsAny<Questionary>())).Callback<Questionary>(ChangeQuestionary);
            mock.Setup(mockRepo => mockRepo.Contains(It.IsAny<Questionary>())).Returns<Questionary>(Contains);
            dao = new QuestionaryDao { Repository = () => repository };
        }

        [Test]
        public void TestAddAndReadQuestionary()
        {
            Assert.AreEqual(0, dao.AllQuestionaries().Count);
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            dao.Add(questionary);
            List<Questionary> allQuestionaries = dao.AllQuestionaries();
            Assert.AreEqual(1, allQuestionaries.Count);
            Assert.IsTrue(ReferenceEquals(questionary, allQuestionaries[0]));
        }

        [Test]
        public void TestHandleException()
        {
            Mock.Get(repository).Setup(mock => mock.AllQuestionaries()).Throws<NotImplementedException>();
            Assert.Catch(typeof(DaoException), () => dao.AllQuestionaries());
        }

        [Test]
        public void TestChangeUnsavedQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            Assert.Throws<DaoException>(() => dao.Change(questionary));
        }

        [Test]
        public void TestUniqueConstraint()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            dao.Add(questionary);
            DaoException daoException = Assert.Throws<DaoException>(() => dao.Add(questionary));
            Assert.AreEqual(ErrorCode.ObjectNotUnique, daoException.ErrorCode);
        }
    }
}
