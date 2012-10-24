using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Server.Handlers
{
    /// <summary>
    /// ���������� �������� �������� ������ (� ������� ����� ����������� ���-������� WCF)
    /// </summary>
    public interface IQuestionaryHandler 
    {
        /// <summary>
        /// �������� ������
        /// </summary>
        /// <param name="questionary">������</param>
        void AddQuestionary(Questionary questionary);
    }
}