namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefautMessage =
            "Created time of message cannot be null or whitespace";
        public EmptyCreatedTimeException()
            :base(DefautMessage) 
        {

        }
        public EmptyCreatedTimeException(string message)
            : base(message)
        {

        }
    }
}
