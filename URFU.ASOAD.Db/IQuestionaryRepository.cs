using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db
{
    /// <summary>
    /// –епозиторий анкет
    /// </summary>
    public interface IQuestionaryRepository : IQuestionaryAccess 
    {
        /// <summary>
        /// ѕроверить наличие анкеты в репозитории
        /// </summary>
        /// <param name="questionary">анкета</param>
        /// <returns>факт наличи€ анкеты в репозирории</returns>
        bool Contains(Questionary questionary);
    }
}