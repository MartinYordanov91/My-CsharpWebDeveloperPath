using LogForU.Core.Appenders.Interface;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interface;
using LogForU.Core.Layouts.Interface;
using LogForU.Core.Models.Interface;

namespace LogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }
        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string content =
                string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            LogFile.WriteLine(content);
            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);

            MessagesAppended++;
        }
    }
}
