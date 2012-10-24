using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Контактная информация
    /// </summary>
    [Serializable]
    public class Contact
    {
        /// <summary>
        /// Адрес прописки
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }
    }
}
