using System;
using System.Collections.Generic;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Анкета
    /// </summary>
    [Serializable]
    public partial class Questionary
    {
        public Questionary()
        {
            Person = new Person();
        }

        /// <summary>
        /// Название курса
        /// </summary>
        public string Course { get; set; } //todo курсов может быть много

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
