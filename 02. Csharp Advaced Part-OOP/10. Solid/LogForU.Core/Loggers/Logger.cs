
namespace LogForU.Core.Loggers
{
    using LogForU.Core.Appenders.Interface;
    using LogForU.Core.Enums;
    using LogForU.Core.Loggers.Interface;
    using LogForU.Core.Models;
    using LogForU.Core.Models.Interface;
    using System;

    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appender)
        {
            this.appenders = appender;
        }


        public void Info(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Info);

        public void Warning(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Warning);

        public void Error(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Error);

        public void Critical(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Critical);

        public void Fatal(string dateTime, string text)
             => AppendAll(dateTime, text, ReportLevel.Fatal);

        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            IMessage message = new Message(dateTime , text , reportLevel);

            foreach (IAppender apender in appenders)
            {
                if (message.ReportLevel >= apender.ReportLevel)
                {
                    apender.AppendMessage(message);
                }
            }
        }
    }
}
