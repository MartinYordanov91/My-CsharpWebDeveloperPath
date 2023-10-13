namespace LogForU.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefautMessage =
            "File name cannot be null or whitespace";
        public EmptyFileNameException()
            :base(DefautMessage) 
        {

        }
        public EmptyFileNameException(string message)
            : base(message)
        {

        }
    }
}
