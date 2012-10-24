using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Область навыков
    /// </summary>
    [Serializable]
    public enum SkillArea
    {
        /// <summary>
        /// Языки
        /// </summary>
        Languages,
        
        /// <summary>
        /// Платформы и технологии
        /// </summary>
        Platforms,

        /// <summary>
        /// Базы данных
        /// </summary>
        Databases,

        /// <summary>
        /// Операционные системы
        /// </summary>
        OperationSystems,

        /// <summary>
        /// Методологии и практики
        /// </summary>
        Methodologies
    }
}
