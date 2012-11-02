using System;
using System.Collections.Generic;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
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
        public List<Questionary> AllQuestionaries()
        {
            List<Questionary> result = null;
            Handle(repository => result = repository.AllQuestionaries());
            return result;
        }

        /// <summary>
        /// Добавить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Add(Questionary questionary)
        {
            Handle(repository =>
            {
                if (repository.Contains(questionary))
                {
                    throw new DaoException(ErrorCode.ObjectNotUnique, questionary.Person.ToString());
                }
                repository.Add(questionary);
            }
            );
        }

        /// <summary>
        /// Изменить анкету
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Change(Questionary questionary)
        {
            if (string.IsNullOrWhiteSpace(questionary.Id))
            {
                throw new DaoException(ErrorCode.CanNotChangeUnsavedObject, typeof(Questionary).Name);
            }
            Handle(repository => repository.Change(questionary));
        }

        private void Handle(Action<IQuestionaryRepository> daoAction)
        {
            try
            {
                daoAction(Repository());
            }
            catch (ASOADException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new DaoException(ErrorCode.DaoException, exception);
            }
        }
    }
}
