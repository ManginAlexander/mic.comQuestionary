namespace URFU.ASOAD.Core
{
    /// <summary>
    /// Коды ошибок в системе
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// {0}
        /// </summary>
        Message = 0,
        /// <summary>
        /// Не найдено сообщение для кода ошибки {0}
        /// </summary>
        ErrorMessageNotFound,
        /// <summary>
        /// Невозможно загрузить хранилище "{0}" по причине: {1}
        /// </summary>
        CanNotLoadRepository,
        /// <summary>
        /// Невозможно сохранить хранилище "{0}" по причине: {1}
        /// </summary>
        CanNotSaveRepository,
        /// <summary>
        /// Ошибка при десериализации объекта типа {0}: {1}
        /// </summary>
        DeserializeException,
        /// <summary>
        /// Ошибка при сериализации объекта типа {0}: {1}
        /// </summary>
        SerializeException,
        /// <summary>
        /// В процессе обработки запроса {0} перехвачено исключение: {1}
        /// </summary>
        HandleException,
        /// <summary>
        /// Ошибка при работе с хранилищем данных: {0}
        /// </summary>
        DaoException,
        /// <summary>
        /// Объект {0} с идентификатором '{1}' не найден в хранилище
        /// </summary>
        ObjectNotFound,
        /// <summary>
        /// Невозможно изменить объект {0}, который ещё не был сохранён в хранилище
        /// </summary>
        CanNotChangeUnsavedObject,
        /// <summary>
        /// При проверке правильности заполнения анкеты обнаружены ошибки: {0}
        /// </summary>
        ValidationError,
        /// <summary>
        /// Анкета "{0}" уже существует в хранилище
        /// </summary>
        ObjectNotUnique
    }
}
