using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Ф.И.О.
    /// </summary>
    [Serializable]
    public class FullName
    {
        private const string NAME_FORMAT = "{0} {1} {2}";

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        public override string ToString()
        {
            return string.Format(NAME_FORMAT, LastName, FirstName, MiddleName);
        }

        protected bool Equals(FullName other)
        {
            return string.Equals(FirstName, other.FirstName) && 
                   string.Equals(LastName, other.LastName) && 
                   string.Equals(MiddleName, other.MiddleName);
        }

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
            return Equals((FullName) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (MiddleName != null ? MiddleName.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
