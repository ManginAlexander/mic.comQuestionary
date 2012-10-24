namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Исключение времени выполнения
    /// </summary>
    public class RunTimeException : ASOADException
    {
        public RunTimeException(string formatMessage, params object[] args) : base(formatMessage, args) {}

        public RunTimeException(ErrorCode errorCode, params object[] args) : base(errorCode, args) { }
    }
}
