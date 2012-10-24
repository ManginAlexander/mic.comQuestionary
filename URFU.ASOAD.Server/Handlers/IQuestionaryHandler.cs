using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Server.Handlers
{
    /// <summary>
    /// Обработчик запросов анкетных данных (в будущем будет интерфейсом веб-сервиса WCF)
    /// </summary>
    public interface IQuestionaryHandler 
    {
        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        void AddQuestionary(Questionary questionary);
    }
}