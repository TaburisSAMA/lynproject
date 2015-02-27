using System;
using System.Diagnostics;

namespace CommonUtility
{
    public class EventLogger : ILogger
    {
        public string Source { get; set; }
        public string LogName { get; set; }

        public EventLogger(string logName = "System", string source = "DefaultSource")
        {
            Source = source;
            LogName = logName;
        }


        private void InitSource()
        {
            if (!(EventLog.SourceExists(Source, Environment.MachineName)))
            {
                EventLog.CreateEventSource(new EventSourceCreationData(Source, LogName));
            }
        }

        private string Exception2String(string message, Exception exception)
        {
            String strExp = "Message: " + message + "\n"; ;
            if (exception != null)
            {
                strExp += "\nException: @ " + exception.TargetSite.Name + "\n";
                strExp += "Exception Message: " + exception.Message + "\n\n";
                strExp += exception.StackTrace;
            }
            return strExp;
        }

        private void Log(string message, int eventId, EventLogEntryType type)
        {
            try
            {
                InitSource();
                EventLog ev = new EventLog(LogName, Environment.MachineName, Source);
                ev.WriteEntry(message, type, eventId);
                ev.Close();
            }
            catch
            {
            }
        }

        public void Debug(object message, int eventId, Exception t)
        {
            Log(Exception2String(message.ToString(), t), eventId, EventLogEntryType.SuccessAudit);
        }

        public void Info(object message, int eventId, Exception t)
        {
            Log(Exception2String(message.ToString(), t), eventId, EventLogEntryType.Information);
        }

        public void Warn(object message, int eventId, Exception t)
        {
            Log(Exception2String(message.ToString(), t), eventId, EventLogEntryType.Warning);
        }

        public void Error(object message, int eventId, Exception t)
        {
            Log(Exception2String(message.ToString(), t), eventId, EventLogEntryType.Error);
        }

        public void Fatal(object message, int eventId, Exception t)
        {
            Log(Exception2String(message.ToString(), t), eventId, EventLogEntryType.FailureAudit);
        }
    }
}
