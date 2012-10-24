using System.Collections.Generic;

using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db.Dao
{
    /// <summary>
    /// Дао по работе с анкетами
    /// </summary>
    public interface IQuestionaryDao 
    {
        /// <summary>
        /// Загрузить все имеющиеся анкеты
        /// </summary>
        /// <returns>список анкет</returns>
        List<Questionary> LoadAllQuestionaries();

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        void AddQuestionary(Questionary questionary);
    }
}