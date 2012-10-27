using System;

using URFU.ASOAD.Db;
using URFU.ASOAD.Db.Dao;
using URFU.ASOAD.Server.Handlers;

namespace URFU.ASOAD.Server
{
    /// <summary>
    /// Временная замена WCF-сервису по обработке анкетных данных
    /// </summary>
    public class RunTimeManager
    {
        private static readonly Lazy<RunTimeManager> lazyInstance = new Lazy<RunTimeManager>(Create);

        public static RunTimeManager Instance { get { return lazyInstance.Value; } }

        private static RunTimeManager Create()
        {
            return new RunTimeManager
            {
                QuestionaryHandler = new QuestionaryHandler
                {
                        Dao = new QuestionaryDao
                        {
                                Repository = () => QuestionaryRepository.Instance
                        }
                }
            };
        }

        private RunTimeManager() { }

        public IQuestionaryHandler QuestionaryHandler { get; private set; }
    }
}
