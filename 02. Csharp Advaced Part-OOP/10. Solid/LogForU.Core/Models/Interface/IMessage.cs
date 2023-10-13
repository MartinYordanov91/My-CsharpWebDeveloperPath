using LogForU.Core.Enums;

namespace LogForU.Core.Models.Interface
{
    public interface IMessage
    {
        string CreatedTime { get; }
        string Text { get; }

        ReportLevel ReportLevel { get; }
    }
}
