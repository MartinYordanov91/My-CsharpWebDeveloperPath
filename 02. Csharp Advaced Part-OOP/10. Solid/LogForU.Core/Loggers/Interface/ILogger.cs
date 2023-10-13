namespace LogForU.Core.Loggers.Interface
{
    public interface ILogger
    {
        void Info(string dataTime, string message);

        void Warning(string dataTime, string message);

        void Error(string dataTime, string message);

        void Critical(string dataTime, string message);

        void Fatal(string dataTime, string message);
    }
}
