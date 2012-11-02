using System.Collections.Generic;

using URFU.ASOAD.Dto;
using URFU.ASOAD.Server;
using URFU.ASOAD.Server.Handlers;

namespace URFU.ASOAD.Web.Model
{
    /// <summary>
    /// Класс инкапсулирует работу с "сервером приложений": пока вызовы идут через RunTimeManager, потом - через WCF
    /// </summary>
    public class QuestionaryWebContext : IQuestionaryAccess
    {
        private IQuestionaryHandler handler { get { return RunTimeManager.Instance.QuestionaryHandler; } }

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Add(Questionary questionary)
        {
            handler.Add(questionary);
        }

        /// <summary>
        /// Изменить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Change(Questionary questionary)
        {
            handler.Change(questionary);
        }

        /// <summary>
        /// Вернуть все имеющиеся анкеты
        /// </summary>
        /// <returns>список всех анкет</returns>
        public List<Questionary> AllQuestionaries()
        {
            return handler.AllQuestionaries();
        }
    }
}