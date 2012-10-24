using System.Collections.Generic;

using NUnit.Framework;

using URFU.ASOAD.Db;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests.Db
{
    [TestFixture]
    public class TestQuestionaryRepository
    {
        private class QuestionaryRepositoryTest : QuestionaryRepository
        {
            public byte[] Data { get; set; }

            protected override byte[] Read()
            {
                return Data;
            }

            protected override void Save(byte[] body)
            {
                Data = body;
            }
        }

        private QuestionaryRepositoryTest repository;

        [SetUp]
        public void SetUp()
        {
            repository = new QuestionaryRepositoryTest();
        }

        [Test]
        public void ReadEmptyTest()
        {
            Assert.AreEqual(0, repository.ReadAll().Count);
        }

        [Test]
        public void AddAndReadTest()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            repository.Add(questionary);
            List<Questionary> questionaries = repository.ReadAll();
            Assert.AreEqual(1, questionaries.Count);
            Assert.AreEqual(questionary.Course, questionaries[0].Course);
            Assert.AreEqual(questionary.SkillThemes.Count, questionaries[0].SkillThemes.Count);
            //todo реализовать полные методы сравнения объектов типа Questionary
        }
    }
}
