using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.LINQ.Task1.Diagnostics.Enums;
using NLog;

namespace MentoringD1D2.LINQ.Task1.Diagnostics
{
    /// <summary>
    /// Class to provide access to the standard logging.
    /// </summary>
    public class ApplicationLogger
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log application messages to app logger with different logging levels.
        /// </summary>
        /// <param name="logMessageType">The levlel of the message to log.</param>
        /// <param name="message">The message to log.</param>
        public static void LogMessage(LogMessageType logMessageType, string message)
        {
            try
            {
                switch (logMessageType)
                {
                    case LogMessageType.Debug:
                        Logger.Debug(message);
                        break;
                    case LogMessageType.Info:
                        Logger.Info(message);
                        break;
                    case LogMessageType.Warn:
                        Logger.Warn(message);
                        break;
                    case LogMessageType.Error:
                        Logger.Error(message);
                        break;
                    case LogMessageType.Fatal:
                        Logger.Fatal(message);
                        break;
                    default:
                        Logger.Info(message);
                        break;
                }
            }
            catch
            {
                // There's nothing can be done if logging fails. At the very least, the sytem should not bubble it up to the user.
            }
        }
    }
}
