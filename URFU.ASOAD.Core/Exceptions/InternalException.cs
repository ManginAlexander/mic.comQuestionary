namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Внутреннее исключение - как правило ошибка разработчика
    /// </summary>
    public class InternalException : ASOADException
    {
        public InternalException(string formatMessage, params object[] args) : base(formatMessage, args) {}

        public InternalException(ErrorCode errorCode, params object[] args) : base(errorCode, args) {}
    }
}
