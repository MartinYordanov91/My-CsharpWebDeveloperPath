
namespace LogForU.CustomLayout
{
    using LogForU.Core.Layouts.Interface;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder stringBuilder = new();
                stringBuilder.AppendLine("<log>");
                stringBuilder.AppendLine("\t<date>{0}</date>");
                stringBuilder.AppendLine("\t<level>{1}</level>");
                stringBuilder.AppendLine("\t<message>{2}</message>");
                stringBuilder.AppendLine("<log>");

                return stringBuilder.ToString();
            }
        }
    }
}
