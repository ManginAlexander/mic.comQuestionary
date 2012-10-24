using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Образование
    /// </summary>
    [Serializable]
    public class Education
    {
        /// <summary>
        /// Учереждение
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Факультет
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Специальность
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public uint Course { get; set; }
    }
}
