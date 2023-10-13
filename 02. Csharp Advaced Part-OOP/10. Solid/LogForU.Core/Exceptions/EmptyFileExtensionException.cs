namespace LogForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefautMessage =
            "File extension cannot be null or whitespace";
        public EmptyFileExtensionException()
            :base(DefautMessage) 
        {

        }
        public EmptyFileExtensionException(string message)
            : base(message)
        {

        }
    }
}
