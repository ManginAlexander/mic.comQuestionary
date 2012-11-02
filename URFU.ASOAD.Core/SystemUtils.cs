using System;

namespace URFU.ASOAD.Core
{
    public static class SystemUtils
    {
        /// <summary>
        /// Вернуть полный путь к каталогу запуска
        /// </summary>
        /// <returns>полный путь к каталогу</returns>
        public static string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
