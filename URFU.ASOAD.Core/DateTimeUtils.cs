using System;
using System.Collections.Generic;

namespace URFU.ASOAD.Core
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Шаблон для форматирования даты без времени
        /// </summary>
        private const string DATE_FORMAT = "dd.MM.yyyy";

        /// <summary>
        /// Шаблон для форматирования даты и времени без миллисекунд
        /// </summary>
        private const string DATETIME_FORMAT = DATE_FORMAT + " HH:mm:ss";

        /// <summary>
        /// Шаблон для форматирования даты и времени с миллисекундами
        /// </summary>
        public const string DATETIME_WITH_MS_FORMAT = DATETIME_FORMAT + ".fff";

        public enum Format
        {
            DateOnly,
            DateTime,
            DateTimeWithMs
        }

        /// <summary>
        /// Доступные форматы датывремени
        /// </summary>
        private static readonly Dictionary<Format, string> dateTimeFormats = new Dictionary<Format, string>
        {
            {Format.DateOnly, DATE_FORMAT },
            {Format.DateTime, DATETIME_FORMAT },
            {Format.DateTimeWithMs, DATETIME_WITH_MS_FORMAT }

        };

        /// <summary>Формирование строкового представления даты-времени</summary>
        /// <param name="dateTime">дата</param>
        /// <param name="format">формат вывода даты</param>
        /// <returns>строка представления даты-времени</returns>
        public static string ToFormatString(this DateTime dateTime, Format format = Format.DateTimeWithMs)
        {
            return dateTime.ToString(dateTimeFormats[format]);
        }
    }
}
