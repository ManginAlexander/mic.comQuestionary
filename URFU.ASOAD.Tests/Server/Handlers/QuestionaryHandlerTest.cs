using System;
using System.Collections.Generic;

using NUnit.Framework;

using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;
using URFU.ASOAD.Server.Handlers;

namespace URFU.ASOAD.Tests.Server.Handlers
{
    [TestFixture]
    public class QuestionaryHandlerTest
    {
        private class QuestionaryDaoTest : IQuestionaryDao //todo переделать на Moq
        {
            public QuestionaryDaoTest()
            {
                AddAction = questionary => Questionaries.Add(questionary);
            }

            public List<Questionary> Questionaries = new List<Questionary>();

            public List<Questionary> LoadAllQuestionaries()
            {
                return Questionaries;
            }

            public Action<Questionary> AddAction { get; set; }

            public void AddQuestionary(Questionary questionary)
            {
                AddAction(questionary);
            }
        }

        private QuestionaryDaoTest dao;

        private QuestionaryHandler handler;

        [SetUp]
        public void SetUp()
        {
            dao = new QuestionaryDaoTest();
            handler = new QuestionaryHandler { Dao = dao };
        }

        [Test]
        public void AddQuestionaryTest()
        {
            Assert.AreEqual(0, dao.Questionaries.Count);
            Questionary questionary = TestObjectsFactory.CreateQuestionary();
            handler.AddQuestionary(questionary);
            Assert.AreEqual(1, dao.Questionaries.Count);
            Assert.IsTrue(ReferenceEquals(questionary, dao.Questionaries[0]));
        }

        [Test]
        public void HandleExceptionTest()
        {
            dao.AddAction = questionary => { throw new NotImplementedException(); };
            Assert.Catch(typeof(HandleException), () => handler.AddQuestionary(null));
        }
    }
}
