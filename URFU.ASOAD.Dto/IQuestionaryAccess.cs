using System.Collections.Generic;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Общий интерфейс по работе с анкетами
    /// </summary>
    public interface IQuestionaryAccess
    {
        /// <summary>
        /// Загрузить все имеющиеся анкеты
        /// </summary>
        /// <returns>список анкет</returns>
        List<Questionary> AllQuestionaries();

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        void Add(Questionary questionary);

        /// <summary>
        /// Изменить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        void Change(Questionary questionary);
    }
}
