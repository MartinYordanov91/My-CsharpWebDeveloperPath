namespace LogForU.Core.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        private const string DefautMessage =
            "Invalid DateTime format";
        public InvalidDateTimeException()
            :base(DefautMessage) 
        {

        }
        public InvalidDateTimeException(string message)
            : base(message)
        {

        }
    }
}
