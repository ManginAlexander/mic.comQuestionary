using System.Collections.Generic;

using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db
{
    /// <summary>
    /// Репозиторий анкет
    /// </summary>
    public interface IQuestionaryRepository 
    {
        /// <summary>
        /// Загрузить все анкеты
        /// </summary>
        /// <returns>набор анкет</returns>
        List<Questionary> ReadAll();

        /// <summary>
        /// Добавить анкету в репозиторий
        /// </summary>
        /// <param name="questionary">анкета</param>
        void Add(Questionary questionary);
    }
}