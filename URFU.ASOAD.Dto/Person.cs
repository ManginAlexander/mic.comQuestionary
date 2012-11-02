using System;

namespace URFU.ASOAD.Dto
{
    /// <summary>
    /// Информация о человеке
    /// </summary>
    [Serializable]
    public class Person
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

        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get { return string.Format(NAME_FORMAT, LastName, FirstName, MiddleName); }}

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Контактная информация
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public Education Education { get; set; }

        public Person()
        {
            Education = new Education();
            Contact = new Contact();
        }

        protected bool Equals(Person other)
        {
            return string.Equals(FullName, other.FullName) && Birthday.Equals(other.Birthday) && 
                   Equals(Contact, other.Contact) && Equals(Education, other.Education);
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
            return Equals((Person)obj);
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
                int hashCode = (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Birthday.GetHashCode();
                hashCode = (hashCode * 397) ^ (Contact != null ? Contact.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Education != null ? Education.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
