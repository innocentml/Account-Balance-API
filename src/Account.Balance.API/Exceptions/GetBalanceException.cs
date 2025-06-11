namespace Account.Balance.API.Exceptions
{
    public class GetBalanceException : Exception
    {
        /// <summary>
        /// Custom exception for handling errors related to getting balance.
        /// </summary>
        private int Code { get; set; }

        /// <summary>
        /// Message describing the exception.
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// Represents an exception that occurs when retrieving a balance fails.
        /// </summary>
        /// <param name="exception">The original exception that caused this exception to be thrown.</param>
        /// <param name="message">A custom message that describes the error.</param>
        /// <param name="code">An error code that provides additional context about the failure.</param>
        public GetBalanceException(Exception exception, string message, int code) : base(exception.Message, exception)
        {
            Message = message;
            Code = code;
        }
    }
}
