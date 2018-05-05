using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredibleBehavioralHealth.Barcode.Common
{
    /// <summary>
    /// Error logger class
    /// </summary>
    public static class ErrorLogger
    {
        private static readonly ILog Log = LogManager.GetLogger("LogFileAppender");
        /// <summary>
        ///     Constructor
        /// </summary>
        static ErrorLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// This method is used to log debug message.
        /// </summary>
        /// <param name="message"></param>
        public static void LogDebug(string message)
        {
            Log.Debug(message);
        }

        /// <summary>
        /// This method is used to log information message.
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// This method is used to log warn message.
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarn(string message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// This method is used to log error message.
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            Log.Error(message);
        }

    }
}
