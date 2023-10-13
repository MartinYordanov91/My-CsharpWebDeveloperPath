namespace LogForU.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefautMessage =
            "Message text cannot be null or whitespace";
        public EmptyMessageTextException()
            :base(DefautMessage) 
        {

        }
        public EmptyMessageTextException(string message)
            : base(message)
        {

        }
    }
}
