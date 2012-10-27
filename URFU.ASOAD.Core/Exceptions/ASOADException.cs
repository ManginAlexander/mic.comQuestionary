using System;
using System.Diagnostics;

namespace URFU.ASOAD.Core.Exceptions
{
    /// <summary>
    /// Базовый класс исключений системы
    /// </summary>
    public abstract class ASOADException : Exception
    {
        private const string EXCEPTION_MESSAGE_FORMAT = "[{0}]: {1}";

        private static readonly TraceSource logger = new TraceSource(typeof(ASOADException).Namespace);

        /// <summary>
        /// Код ошибки
        /// </summary>
        public readonly ErrorCode ErrorCode;

        /// <summary>
        /// Исключение с текстом сообщения об ошибке и аргументами
        /// </summary>
        /// <param name="formatMessage">форматное сообщение</param>
        /// <param name="args">аргументы</param>
        protected ASOADException(string formatMessage, object[] args) : this(ErrorCode.Message, GetMessage(formatMessage, args)) { }

        /// <summary>Исключение с заданным кодом (сообщение соответствует коду)</summary>
        /// <param name="errorCode">код ошибки</param>
        /// <param name="args">параметры для подстановки в текст ошибки</param>
        protected ASOADException(ErrorCode errorCode, params object[] args) : base(GetMessage(errorCode, args))
        {
            ErrorCode = errorCode;
            logger.TraceEvent(TraceEventType.Error, (int)errorCode, GetMessage(ErrorCode, args));
        }

        public static string GetMessage(ErrorCode errorCode, object[] args)
        {
            string code = errorCode.ToString();
            string formatMessage = Messages.ResourceManager.GetString(code);
            if (string.IsNullOrWhiteSpace(formatMessage))
            {
                logger.TraceEvent(TraceEventType.Error, (int)ErrorCode.ErrorMessageNotFound, Messages.ErrorMessageNotFound, code);
                return string.Empty;
            }
            string errorMessage = GetMessage(formatMessage, args);
            if (errorCode != ErrorCode.Message) //смысла в указании этого кода ошибки нет
            {
                errorMessage = string.Format(EXCEPTION_MESSAGE_FORMAT, errorCode, errorMessage); 
            }
            return errorMessage;
        }
        
        private static string GetMessage(string formatMessage, object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return formatMessage;
            }
            return string.Format(formatMessage, args);
        }
    }
}
