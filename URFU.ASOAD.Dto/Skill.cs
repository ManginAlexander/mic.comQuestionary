using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Характеристика навыка
    /// </summary>
    [Serializable]
    public class Skill
    {
        /// <summary>
        /// Принадлежность к группе навыков
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Название навыка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Теоретические знания
        /// </summary>
        public bool Theory { get; set; }

        /// <summary>
        /// Практические знания
        /// </summary>
        public bool Practice { get; set; }
    }
}
