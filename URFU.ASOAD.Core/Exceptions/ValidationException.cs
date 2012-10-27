namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Ошибки, выявленные при валидации
    /// </summary>
    public class ValidationException : ASOADException
    {
        public ValidationException(string formatMessage, params object[] args) : base(formatMessage, args) {}

        public ValidationException(ErrorCode errorCode, params object[] args) : base(errorCode, args) { }
    }
}
