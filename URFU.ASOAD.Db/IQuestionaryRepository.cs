using System.Collections.Generic;

using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db
{
    /// <summary>
    /// ����������� �����
    /// </summary>
    public interface IQuestionaryRepository 
    {
        /// <summary>
        /// ��������� ��� ������
        /// </summary>
        /// <returns>����� �����</returns>
        List<Questionary> ReadAll();

        /// <summary>
        /// �������� ������ � �����������
        /// </summary>
        /// <param name="questionary">������</param>
        void Add(Questionary questionary);
    }
}