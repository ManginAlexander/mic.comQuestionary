using System.Collections.Generic;

namespace URFU.ASOAD.Dto.Resolvers
{
    /// <summary>
    /// Разрешатель названия области навыков по типу навыка
    /// </summary>
    public static class SkillAreaResolver
    {
        /// <summary>
        /// Наименования областей навыков
        /// </summary>
        public static readonly Dictionary<SkillArea, string> SkillThemeTitles = new Dictionary<SkillArea, string>
        {
            { SkillArea.Languages, "Языки программирования" },
            { SkillArea.Platforms, "Платформы и технологии" },
            { SkillArea.Databases, "Базы данных" },
            { SkillArea.OperationSystems, "Операционные системы" },
            { SkillArea.Methodologies, "Методологии и практики" }
        };
    }
}
