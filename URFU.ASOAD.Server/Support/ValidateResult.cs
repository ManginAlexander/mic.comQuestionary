using System.Collections.Generic;
using System.Text;

namespace URFU.ASOAD.Server.Support
{
    /// <summary>
    /// Результат валидации. todo нужно реализовать удобный интерфейс добавления сообщений о найденных ошибках
    /// </summary>
    public class ValidateResult
    {
        private readonly List<string> errors = new List<string>();

        public bool IsValid { get { return errors.Count == 0; } }

        public void Add(string errorMessage)
        {
            errors.Add(errorMessage);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string error in errors)
            {
                stringBuilder.AppendLine(error);
            }
            return stringBuilder.ToString();
        }
    }
}
