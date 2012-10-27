using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests
{
    public abstract class BaseQuestionaryAccessTest
    {
        private Dictionary<string, Questionary> testQuestionaries;

        protected void ChangeQuestionary(Questionary questionary)
        {
            if (!testQuestionaries.ContainsKey(questionary.Id))
            {
                throw new InternalException("нет анкеты для обновления");
            }
            testQuestionaries[questionary.Id] = questionary;
        }

        protected void AddQuestionary(Questionary questionary)
        {
            questionary.Id = Guid.NewGuid().ToString();
            testQuestionaries.Add(questionary.Id, questionary);
        }

        protected List<Questionary> ReadAllQuestionaries()
        {
            return TestQuestionaries;
        } 

        protected List<Questionary> TestQuestionaries {get { return testQuestionaries.Values.ToList(); }}

        [SetUp]
        public virtual void SetUp()
        {
            testQuestionaries = new Dictionary<string, Questionary>();
        }
    }
}
