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

        protected bool Equals(Education other)
        {
            return string.Equals(Organization, other.Organization) && 
                   string.Equals(Department, other.Department) && 
                   string.Equals(Speciality, other.Speciality) && 
                   Course == other.Course;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((Education)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"/>.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Organization != null ? Organization.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Department != null ? Department.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Speciality != null ? Speciality.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Course;
                return hashCode;
            }
        }
    }
}
