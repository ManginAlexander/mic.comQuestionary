using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Server.Support
{
    /// <summary>
    /// Валидатор корректности заполненной анкеты todo написать тесты на валидатор
    /// </summary>
    public class QuestionaryValidator
    {
        /// <summary>
        /// Выполнить проверки валидности заполнения анкеты
        /// </summary>
        /// <param name="questionary">анкета</param>
        public ValidateResult Validate(Questionary questionary)
        {
            ValidateResult result = new ValidateResult();
            //todo тут проверки валидации анкеты с заполнением ValidateResult, например:
            if (string.IsNullOrWhiteSpace(questionary.Person.FirstName))
            {
                result.Add("Не заполнено поле 'Имя'");
            }
            return result;
        }

        
    }
}
