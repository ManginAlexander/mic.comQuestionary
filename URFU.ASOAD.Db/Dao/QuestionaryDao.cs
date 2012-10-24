using System;
using System.Collections.Generic;

using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db.Dao
{
    /// <summary>
    /// Реализация дао по работе с анкетами
    /// </summary>
    public class QuestionaryDao : IQuestionaryDao
    {
        public Func<IQuestionaryRepository> Repository { get; set; }

        /// <summary>
        /// Загрузить все имеющиеся анкеты
        /// </summary>
        /// <returns>список анкет</returns>
        public List<Questionary> LoadAllQuestionaries()
        {
            return Repository().ReadAll();
        }

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void AddQuestionary(Questionary questionary)
        {
            Repository().Add(questionary);
        }
    }
}
