using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db
{
    /// <summary>
    /// ����������� �����
    /// </summary>
    public interface IQuestionaryRepository : IQuestionaryAccess 
    {
        /// <summary>
        /// ��������� ������� ������ � �����������
        /// </summary>
        /// <param name="questionary">������</param>
        /// <returns>���� ������� ������ � �����������</returns>
        bool Contains(Questionary questionary);
    }
}