namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Исключение при работе с дао
    /// </summary>
    public class DaoException : ASOADException
    {
        public DaoException(string formatMessage, params object[] args) : base(formatMessage, args) {}

        public DaoException(ErrorCode errorCode, params object[] args) : base(errorCode, args) { }
    }
}
