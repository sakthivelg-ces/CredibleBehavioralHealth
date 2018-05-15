using log4net;

namespace CredibleBehavioralHealth.Barcode.Common
{
    /// <summary>
    /// Error logger class
    /// </summary>
    public class Logger : ILogger
    {
        private readonly ILog Log = LogManager.GetLogger("LogFileAppender");
        /// <summary>
        ///     Constructor
        /// </summary>
        public Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// This method is used to log debug message.
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            Log.Debug(message);
        }

        /// <summary>
        /// This method is used to log information message.
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// This method is used to log warn message.
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// This method is used to log error message.
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            Log.Error(message);
        }

    }
}
