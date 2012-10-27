using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using URFU.ASOAD.Core;
using URFU.ASOAD.Core.Exceptions;
using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db
{
    /// <summary>
    /// Реализация репозитория анкет
    /// </summary>
    public class QuestionaryRepository : IQuestionaryRepository
    {
        /// <summary>
        /// Имя файла репозитория
        /// </summary>
        private const string REPOSITORY_FILE_NAME = "data.repository";

        private const string UNIQUE_ID_FORMAT = "{0} {1}";

        private static readonly Lazy<QuestionaryRepository> lazyInstance = new Lazy<QuestionaryRepository>(Create, LazyThreadSafetyMode.ExecutionAndPublication);

        protected QuestionaryRepository() {}

        private static QuestionaryRepository Create()
        {
            return new QuestionaryRepository();
        }

        /// <summary>
        /// Единственный экземпляр репозитория
        /// </summary>
        public static QuestionaryRepository Instance { get { return lazyInstance.Value; } }

        private volatile SortedDictionary<string, Questionary> repository = new SortedDictionary<string, Questionary>();

        private volatile bool isLoaded;

        /// <summary>
        /// Загрузить все анкеты
        /// </summary>
        /// <returns>набор анкет</returns>
        public List<Questionary> AllQuestionaries()
        {
            Init();
            return repository.Values.ToList();
        }

        /// <summary>
        /// Добавить анкету в репозиторий
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Add(Questionary questionary)
        {
            Init();
            lock (this)
            {
                questionary.Id = GetUniqueId(questionary.Person);
                repository.Add(questionary.Id, questionary);
                Save(ObjectUtils.Serialize(repository));
            }
        }

        /// <summary>
        /// Изменить анкету в репозитории
        /// </summary>
        /// <param name="questionary">анкета</param>
        public void Change(Questionary questionary)
        {
            Init();
            lock (this)
            {
                if (string.IsNullOrWhiteSpace(questionary.Id) || !repository.ContainsKey(questionary.Id))
                {
                    throw new DaoException(ErrorCode.ObjectNotFound, typeof(Questionary).Name, questionary.Id);
                }
                string id = GetUniqueId(questionary.Person);
                if (questionary.Id != id) //изменилась ключевая информация
                {
                    repository.Remove(questionary.Id);
                    repository.Add(questionary.Id = id, questionary);
                }
                else
                {
                    repository[id] = questionary;
                }
                Save(ObjectUtils.Serialize(repository));
            }
        }

        /// <summary>
        /// Псевдоуникальный идентификатор сохранённого в репозитории объекта
        /// </summary>
        /// <param name="person">анкетируемый</param>
        /// <returns>идентификатор</returns>
        private string GetUniqueId(Person person)
        {
            return string.Format(UNIQUE_ID_FORMAT, person.FullName, person.Birthday.ToFormatString());
        }

        /// <summary>
        /// Сохранить репозиторий
        /// </summary>
        /// <param name="body">бинарное представление репозитория</param>
        protected virtual void Save(byte[] body)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(REPOSITORY_FILE_NAME, FileMode.Create)))
                {
                    writer.Write(body);
                }
            }
            catch (Exception exception)
            {
                throw new RunTimeException(ErrorCode.CanNotSaveRepository, Path.GetFullPath(REPOSITORY_FILE_NAME), exception.Message);
            }
        }

        /// <summary>
        /// Загрузить репозиторий
        /// </summary>
        /// <returns>бинарное представление репозитория</returns>
        protected virtual byte[] Read()
        {
            if (!File.Exists(REPOSITORY_FILE_NAME))
            {
                return null;
            }
            try
            {
                return File.ReadAllBytes(REPOSITORY_FILE_NAME);
            }
            catch (Exception exception)
            {
                throw new RunTimeException(ErrorCode.CanNotLoadRepository, Path.GetFullPath(REPOSITORY_FILE_NAME), exception.Message);
            }
        }

        /// <summary>
        /// Дабл-чек для первоначальной инициализации хранилища
        /// </summary>
        private void Init()
        {
            if (isLoaded)
            {
                return;
            }
            lock (this)
            {
                if (!isLoaded)
                {
                    Load();
                    isLoaded = true;
                }
            }
        }

        private void Load()
        {
            lock (this)
            {
                byte[] content = Read();
                if (content != null)
                {
                    repository = ObjectUtils.Deserialize<SortedDictionary<string, Questionary>>(content);
                }
            }
        }
    }
}
