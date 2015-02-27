using System;

namespace CommonUtility
{
    public interface ILogger
    {
        void Debug(object message, int eventId = 0, Exception t = null);
        void Info(object message, int eventId = 0, Exception t = null);
        void Warn(object message, int eventId = 0, Exception t = null);
        void Error(object message, int eventId = 0, Exception t = null);
        void Fatal(object message, int eventId = 0, Exception t = null);
    }
}
