using System;
using System.Diagnostics;
using log4net;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: log4net.Config.Repository()]

namespace CommonUtilities
{


    public class Logger
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public const String SOURCE = "COMOfficeControl";
        public const String LOGNAME = "CIMS";


        //public static void Log(String message, int eventId, EventLogEntryType type)

        public static void Log(String message, int eventId, EventLogEntryType type)
        {
            switch (type)
            {
                case EventLogEntryType.Error:
                    _logger.Error(message);
                    break;
                case EventLogEntryType.Warning:
                    _logger.Warn(message);
                    break;
                case EventLogEntryType.Information:
                    _logger.Info(message);
                    break;
                default:
                    _logger.Error(message);
                    break;
            }
        }

        public static void Info(String text, int eventId)
        {
            Log(text, eventId, EventLogEntryType.Information);
        }
        public static void Warning(String text, int eventId)
        {
            Log(text, eventId, EventLogEntryType.Warning);
        }
        public static void Error(String text, int eventId)
        {
            Log(text, eventId, EventLogEntryType.Error);
        }


        public static void Exception(Exception exp, int eventId)
        {
            Exception(exp, eventId, null, EventLogEntryType.Error);
        }
        public static void Exception(Exception exp, int eventId, string description)
        {
            Exception(exp, eventId, description, EventLogEntryType.Error);
        }
        public static void Exception(Exception exp, int eventId, string description, EventLogEntryType type)
        {
            var strExp = "Exception: @ " + exp.TargetSite.Name + "\r\n";
            if (description != null)
                strExp += "Description: \r\n" + description + "\r\n";

            strExp += exp.Message + "\r\n\r\n";
            strExp += exp.StackTrace;

            Log(strExp, eventId, EventLogEntryType.Error);
        }
    }
}
