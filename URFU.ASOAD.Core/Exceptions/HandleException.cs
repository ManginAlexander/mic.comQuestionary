namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Ошибки обработчиков бизнес-логики
    /// </summary>
    public class HandleException : ASOADException
    {
        public HandleException(string formatMessage, params object[] args) : base(formatMessage, args) {}

        public HandleException(ErrorCode errorCode, params object[] args) : base(errorCode, args) { }
    }
}
