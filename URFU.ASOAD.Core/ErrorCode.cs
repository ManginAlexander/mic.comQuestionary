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
        /// Невозможно загрузить репозиторий "{}" по причине: {1}
        /// </summary>
        CanNotLoadRepository,
        /// <summary>
        /// Невозможно сохранить репозиторий "{}" по причине: {1}
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
        HandleException
    }
}
