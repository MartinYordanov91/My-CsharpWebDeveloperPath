namespace LogForU.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefautMessage =
            "Path is invalid or empty";
        public InvalidPathException()
            :base(DefautMessage) 
        {

        }
        public InvalidPathException(string message)
            : base(message)
        {

        }
    }
}
