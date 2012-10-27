using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests.Db
{
    [TestFixture]
    public class QuestionaryRepositoryTest
    {
        private class FakeQuestionaryRepository : QuestionaryRepository
        {
            private byte[] Data { get; set; }

            protected override byte[] Read()
            {
                return Data;
            }

            protected override void Save(byte[] body)
            {
                Data = body;
            }
        }

        private FakeQuestionaryRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new FakeQuestionaryRepository();
        }

        [Test]
        public void TestReadEmpty()
        {
            Assert.AreEqual(0, repository.AllQuestionaries().Count);
        }

        [Test]
        public void TestAddAndRead()
        {
            Questionary questionary = AddQuestionary();
            List<Questionary> questionaries = repository.AllQuestionaries();
            Assert.AreEqual(1, questionaries.Count);
            Assert.AreEqual(questionary.Course, questionaries[0].Course);
            Assert.AreEqual(questionary.SkillThemes.Count, questionaries[0].SkillThemes.Count);
            //todo реализовать полные методы сравнения объектов типа Questionary
        }

        [Test]
        public void TestChangeImportantInfo()
        {
            Questionary questionary = AddQuestionary();
            questionary.Person.FirstName = Guid.NewGuid().ToString();
            repository.Change(questionary);
            List<Questionary> questionaries = repository.AllQuestionaries();
            Assert.AreEqual(1, questionaries.Count);
            Assert.AreEqual(questionary.Person.FirstName, questionaries[0].Person.FirstName);
        }

        [Test]
        public void TestChange()
        {
            Questionary questionary = AddQuestionary();
            Skill testSkill = questionary.SkillThemes.First().Skills.First();
            bool testValue = !testSkill.Practice;
            testSkill.Practice = testValue;
            repository.Change(questionary);
            Assert.AreEqual(testValue, repository.AllQuestionaries().First().SkillThemes.First().Skills.First().Practice);
        }

        [Test]
        public void TestChangeAbsentQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            questionary.Id = Guid.NewGuid().ToString(); //как будто-бы сохраняли уже
            DaoException exception = Assert.Throws<DaoException>(() => repository.Change(questionary));
            Assert.AreEqual(ErrorCode.ObjectNotFound, exception.ErrorCode);
        }

        private Questionary AddQuestionary()
        {
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            repository.Add(questionary);
            return questionary;
        }
    }
}
