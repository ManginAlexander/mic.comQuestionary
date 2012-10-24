using System;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Server.Handlers
{
    /// <summary>
    /// Реализация обработчика запросов по обработке анкет
    /// </summary>
    public class QuestionaryHandler : IQuestionaryHandler
    {
        public IQuestionaryDao Dao { private get; set; }

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void AddQuestionary(Questionary questionary)
        {
            Handle(() =>
            {
                //todo проверка валидности заполненной анкеты
                //todo проверка уникальности анкеты
                Dao.AddQuestionary(questionary);
            });
        }

        /// <summary>
        /// Запуск обработчика с перехватом исключений:
        /// - уже обработанные исключения можно вернуть как есть
        /// - необработанные оборачиваются в HandleException
        /// </summary>
        /// <param name="handler">обработчик</param>
        private void Handle(Action handler)
        {
            try
            {
                handler();
            }
            catch (ASOADException)
            {
                throw; 
            }
            catch (Exception exception)
            {
                throw new HandleException(ErrorCode.HandleException, ObjectUtils.CallerMethodName(), exception);
            }
        }
    }
}
