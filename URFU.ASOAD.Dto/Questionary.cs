using System;
using System.Collections.Generic;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Анкета
    /// </summary>
    [Serializable]
    public class Questionary
    {
        /// <summary>
        /// Название курса
        /// </summary>
        public string Course { get; set; }

        /// <summary>
        /// Информация о человеке
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Перечень навыков по темам
        /// </summary>
        public List<SkillTheme> SkillThemes { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
