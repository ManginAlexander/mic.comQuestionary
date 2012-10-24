using System.Collections.Generic;

using URFU.ASOAD.Dto;

namespace URFU.ASOAD.Db.Dao
{
    /// <summary>
    /// ��� �� ������ � ��������
    /// </summary>
    public interface IQuestionaryDao 
    {
        /// <summary>
        /// ��������� ��� ��������� ������
        /// </summary>
        /// <returns>������ �����</returns>
        List<Questionary> LoadAllQuestionaries();

        /// <summary>
        /// �������� ������
        /// </summary>
        /// <param name="questionary">������</param>
        void AddQuestionary(Questionary questionary);
    }
}