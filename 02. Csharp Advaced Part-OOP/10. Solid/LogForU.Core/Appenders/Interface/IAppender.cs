using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interface;
using LogForU.Core.Models.Interface;

namespace LogForU.Core.Appenders.Interface
{
    public interface IAppender
    {

        public ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; }
        void AppendMessage(IMessage message);
    }
}
