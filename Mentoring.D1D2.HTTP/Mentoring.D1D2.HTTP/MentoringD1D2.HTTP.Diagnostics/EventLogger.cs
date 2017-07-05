using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace MentoringD1D2.HTTP.Diagnostics
{
    /// <summary>
    /// Logging operations
    /// </summary>
    public class EventLogger : ILogger
    {
       
        /// <summary>
        /// The actual limit is higher than this, but different Microsoft operating systems actually have different limits.
        /// </summary>
        private const int MaxEventLogEntryLength = 30000;

        /// <summary>
        /// Gets or sets the source/caller.
        /// </summary>
        public static string Source { get; set; }

        /// <summary>
        /// Log application messages to app logger with different logging levels.
        /// </summary>
        /// <param name="logMessageType">The levlel of the message to log.</param>
        /// <param name="message">The message to log.</param>
        public void LogMessage(LogMessageType logMessageType, string message)
        {
            try
            {
                switch (logMessageType)
                {
                    case LogMessageType.Debug:
                        LogDebug(message);
                        break;
                    case LogMessageType.Info:
                        LogInformation(message);
                        break;
                    case LogMessageType.Warn:
                        LogWarning(message);
                        break;
                    case LogMessageType.Error:
                        LogError(message);
                        break;
                    default:
                        LogInformation(message);
                        break;
                }
            }
            catch
            {
                // There's nothing can be done if logging fails. At the very least, the sytem should not bubble it up to the user.
            }
        }

        /// <summary>
        /// Logs the message, but only if debug logging is true.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="source">The name of the app/process calling the logging method. If not provided,
        /// an attempt will be made to get the name of the calling process.</param>
        private static void LogDebug(string message, string source = "Application")
        {
            Log(message, EventLogEntryType.Information, source);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="source">The name of the app/process calling the logging method. If not provided,
        /// an attempt will be made to get the name of the calling process.</param>
        private static void LogInformation(string message, string source = "Application")
        {
            Log(message, EventLogEntryType.Information, source);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="source">The name of the app/process calling the logging method. If not provided,
        /// an attempt will be made to get the name of the calling process.</param>
        private static void LogWarning(string message, string source = "Application")
        {
            Log(message, EventLogEntryType.Warning, source);
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="source">The name of the app/process calling the logging method. If not provided,
        /// an attempt will be made to get the name of the calling process.</param>
        private static void LogError(string message, string source = "Application")
        {
            Log(message, EventLogEntryType.Error, source);
        }


        /// <summary>
        ///  Log application messages to app logger with different logging levels into windows logs.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="entryType">The levlel of the message to log.</param>
        /// <param name="source">The name of the event log.</param>
        private static void Log(string message, EventLogEntryType entryType, string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                source = GetSource();
            }

            var possiblyTruncatedMessage = EnsureLogMessageLimit(message);
            EventLog.WriteEntry(source, possiblyTruncatedMessage, entryType);
        }

        /// <summary>
        /// Gets the source/caller by assembly name.
        /// </summary>
        /// <returns>The source.</returns>
        private static string GetSource()
        {
            if (!string.IsNullOrWhiteSpace(Source)) { return Source; }

            try
            {
                var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();

                return assembly.GetName().Name;
            }
            catch
            {
                return "Unknown Applocation";
            }
        }


        /// <summary>
        /// Ensures that the log message entry text length does not exceed the event log viewer maximum length of 32766 characters.
        /// </summary>
        /// <param name="logMessage">The message.</param>
        /// <returns>The verified  message.</returns>
        private static string EnsureLogMessageLimit(string logMessage)
        {
            if (logMessage.Length <= MaxEventLogEntryLength)
                return logMessage;

            var truncateWarningText = string.Format(CultureInfo.CurrentCulture, "... | Log Message Truncated [ Limit: {0} ]", MaxEventLogEntryLength);
            
            logMessage = logMessage.Substring(0, MaxEventLogEntryLength - truncateWarningText.Length);

            logMessage = $"{logMessage} {truncateWarningText}";

            return logMessage;
        }
    }
}