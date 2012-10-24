using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Информация о человеке
    /// </summary>
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Полное имя
        /// </summary>
        public FullName FullName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Контактная информация
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public Education Education { get; set; }
    }
}
