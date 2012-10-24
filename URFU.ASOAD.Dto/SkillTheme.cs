using System;
using System.Collections.Generic;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Набор навыков определённой темы
    /// </summary>
    [Serializable]
    public class SkillTheme
    {
        /// <summary>
        /// Тема
        /// </summary>
        public SkillArea Area { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Набор навыков
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
