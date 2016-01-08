using log4net;

namespace FractionalCalculator.Loggers
{
    public static class Logger
    {
        private static ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogError(object message)
        {
            _logger.Error(message);
        }

        public static void LogWarn(object message)
        {
            _logger.Warn(message);
        }

        public static void LogInfo(object message)
        {
            _logger.Info(message);
        }

        public static void LogDebug(object message)
        {
            _logger.Debug(message);
        }
    }
}