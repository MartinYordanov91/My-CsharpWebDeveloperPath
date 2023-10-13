using LogForU.Core.Layouts.Interface;

namespace LogForU.Core.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string simpleFormat = "{0} - {1} - {2}";
        public string Format
            => simpleFormat;
    }
}
