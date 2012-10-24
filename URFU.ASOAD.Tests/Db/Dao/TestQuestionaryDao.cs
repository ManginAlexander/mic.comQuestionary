using System.Collections.Generic;

using NUnit.Framework;

using URFU.ASOAD.Db;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests.Db.Dao
{
    [TestFixture]
    public class TestQuestionaryDao
    {
        private class QuestionaryRepositoryTest : IQuestionaryRepository //todo переделать тест на Moq-объекты
        {
            public List<Questionary> Questionaries = new List<Questionary>();

            public List<Questionary> ReadAll()
            {
                return Questionaries;
            }

            public void Add(Questionary questionary)
            {
                Questionaries.Add(questionary);
            }
        }

        private QuestionaryRepositoryTest repository;

        [SetUp]
        public void SetUp()
        {
            repository = new QuestionaryRepositoryTest();
        }

        [Test]
        public void AddQuestionaryTest()
        {
            IQuestionaryDao dao = new QuestionaryDao {Repository = () => repository};
            Assert.AreEqual(0, dao.LoadAllQuestionaries().Count);
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            dao.AddQuestionary(questionary);
            List<Questionary> allQuestionaries = dao.LoadAllQuestionaries();
            Assert.AreEqual(1, allQuestionaries.Count);
            Assert.IsTrue(object.ReferenceEquals(questionary, allQuestionaries[0]));
        }
    }
}
