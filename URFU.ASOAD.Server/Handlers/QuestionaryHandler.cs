using System;
using System.Collections.Generic;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Dto;
using URFU.ASOAD.Server.Support;

namespace URFU.ASOAD.Server.Handlers
{
    /// <summary>
    /// Реализация обработчика запросов по обработке анкет (в будущем реализация веб-сервиса WCF)
    /// </summary>
    public class QuestionaryHandler : IQuestionaryHandler
    {
        public IQuestionaryDao Dao { private get; set; }

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Add(Questionary questionary)
        {
            Handle(() =>
            {
                Validate(questionary);
                Dao.Add(questionary);
            });
        }

        /// <summary>
        /// Вернуть все имеющиеся анкеты
        /// </summary>
        /// <returns>список всех анкет</returns>
        public List<Questionary> AllQuestionaries()
        {
            List<Questionary> result = new List<Questionary>();
            Handle(() =>
            {
                result = Dao.AllQuestionaries();
            });
            return result;
        }

        /// <summary>
        /// Изменить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Change(Questionary questionary)
        {
            Handle(() =>
            {
                Validate(questionary);
                Dao.Change(questionary);
            });
        }

        private void Validate(Questionary questionary)
        {
            QuestionaryValidator validator = new QuestionaryValidator();
            ValidateResult validateResult = validator.Validate(questionary);
            if (!validateResult.IsValid)
            {
                throw new ValidationException(ErrorCode.ValidationError, validateResult.ToString());
            }
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
