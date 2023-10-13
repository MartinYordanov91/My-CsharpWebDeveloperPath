using LogForU.Core.Appenders.Interface;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interface;
using LogForU.Core.Models.Interface;

namespace LogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            Console.WriteLine(string.Format(Layout.Format , message.CreatedTime , message.ReportLevel ,message.Text));

            MessagesAppended++;
        }
    }
}
