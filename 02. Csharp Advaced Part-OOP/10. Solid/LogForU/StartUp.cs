namespace LogForU
{
    using LogForU.Core.Appenders;
    using LogForU.Core.Appenders.Interface;
    using LogForU.Core.Layouts;
    using LogForU.Core.Layouts.Interface;
    using LogForU.Core.Loggers;
    using LogForU.Core.Loggers.Interface;
    using LogForU.Core.Utils;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ILayout layout = new SimpleLayout();
            IAppender appender = new ConsoleAppender(layout);

            ILogger logger = new Logger(appender);

            //DateTimeValidator.AddFormat("MM/dd/yyyy h:mm:ss tt");
            //logger.Info("03/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}