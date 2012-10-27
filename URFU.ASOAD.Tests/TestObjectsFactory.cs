using System;
using System.Globalization;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Factories;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Tests
{
    public static class TestObjectsFactory
    {
        public static Questionary CreateQuestionary()
        {
            Questionary questionary = QuestionaryFactory.Create();
            new DataGenerator().FillObject(questionary);
            questionary.Id = null; //идентификатор при сохранении
            return questionary;
        }

        public static DateTime ToDate(string stringValue)
        {
            return DateTime.ParseExact(stringValue, DateTimeUtils.DATETIME_WITH_MS_FORMAT, CultureInfo.InvariantCulture);
        }
    }
}
