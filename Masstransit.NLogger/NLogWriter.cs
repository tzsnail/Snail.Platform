namespace MassTransit.NLogger
{
    using System;
    using System.Globalization;
    using ILogWriter = MassTransit.Logging.ILog;
    using INLogger = NLog.ILogger;
    using LogLevel = MassTransit.Logging.LogLevel;
    using LogOutputProvider = MassTransit.Logging.LogOutputProvider;

    public class NLogWriter : ILogWriter
    {
        private readonly INLogger _log;

        public bool IsDebugEnabled
        {
            get
            {
                return this._log.IsDebugEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return this._log.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return this._log.IsWarnEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return this._log.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return this._log.IsFatalEnabled;
            }
        }

        public NLogWriter(INLogger log)
        {
            this._log = log;
        }

        public void Debug(object message)
        {
            this._log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            this._log.Debug(exception, (string)message);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            if (!this.IsDebugEnabled)
            {
                return;
            }
            this._log.Debug(messageProvider());
        }

        public void DebugFormat(string format, params object[] args)
        {
            this._log.Debug(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this._log.Debug(provider, format, args);
        }

        public void Info(object message)
        {
            this._log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            this._log.Info(exception, (string)message);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            if (!this.IsInfoEnabled)
            {
                return;
            }
            this._log.Info(messageProvider());
        }

        public void InfoFormat(string format, params object[] args)
        {
            this._log.Info(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this._log.Info(provider, format, args);
        }

        public void Warn(object message)
        {
            this._log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            this._log.Warn(exception, (string)message);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            if (!this.IsWarnEnabled)
            {
                return;
            }
            this._log.Warn(messageProvider());
        }

        public void WarnFormat(string format, params object[] args)
        {
            this._log.Warn(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this._log.Warn(provider, format, args);
        }

        public void Error(object message)
        {
            this._log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            this._log.Error(exception, (string)message);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            if (!this.IsErrorEnabled)
            {
                return;
            }
            this._log.Error(messageProvider());
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this._log.Error(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this._log.Error(provider, format, args);
        }

        public void Fatal(object message)
        {
            this._log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            this._log.Fatal(exception, (string)message);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            if (!this.IsFatalEnabled)
            {
                return;
            }
            this._log.Fatal(messageProvider());
        }

        public void FatalFormat(string format, params object[] args)
        {
            this._log.Fatal(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this._log.Fatal(provider, format, args);
        }

        public void Log(LogLevel level, object obj)
        {
            if (level == LogLevel.Fatal)
            {
                this.Fatal(obj);
                return;
            }
            if (level == LogLevel.Error)
            {
                this.Error(obj);
                return;
            }
            if (level == LogLevel.Warn)
            {
                this.Warn(obj);
                return;
            }
            if (level == LogLevel.Info)
            {
                this.Info(obj);
                return;
            }
            if (level >= LogLevel.Debug)
            {
                this.Debug(obj);
            }
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            if (level == LogLevel.Fatal)
            {
                this.Fatal(obj, exception);
                return;
            }
            if (level == LogLevel.Error)
            {
                this.Error(obj, exception);
                return;
            }
            if (level == LogLevel.Warn)
            {
                this.Warn(obj, exception);
                return;
            }
            if (level == LogLevel.Info)
            {
                this.Info(obj, exception);
                return;
            }
            if (level >= LogLevel.Debug)
            {
                this.Debug(obj, exception);
            }
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            if (level == LogLevel.Fatal)
            {
                this.Fatal(messageProvider);
                return;
            }
            if (level == LogLevel.Error)
            {
                this.Error(messageProvider);
                return;
            }
            if (level == LogLevel.Warn)
            {
                this.Warn(messageProvider);
                return;
            }
            if (level == LogLevel.Info)
            {
                this.Info(messageProvider);
                return;
            }
            if (level >= LogLevel.Debug)
            {
                this.Debug(messageProvider);
            }
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            if (level == LogLevel.Fatal)
            {
                this.FatalFormat(CultureInfo.InvariantCulture, format, args);
                return;
            }
            if (level == LogLevel.Error)
            {
                this.ErrorFormat(CultureInfo.InvariantCulture, format, args);
                return;
            }
            if (level == LogLevel.Warn)
            {
                this.WarnFormat(CultureInfo.InvariantCulture, format, args);
                return;
            }
            if (level == LogLevel.Info)
            {
                this.InfoFormat(CultureInfo.InvariantCulture, format, args);
                return;
            }
            if (level >= LogLevel.Debug)
            {
                this.DebugFormat(CultureInfo.InvariantCulture, format, args);
            }
        }

        public void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (level == LogLevel.Fatal)
            {
                this.FatalFormat(formatProvider, format, args);
                return;
            }
            if (level == LogLevel.Error)
            {
                this.ErrorFormat(formatProvider, format, args);
                return;
            }
            if (level == LogLevel.Warn)
            {
                this.WarnFormat(formatProvider, format, args);
                return;
            }
            if (level == LogLevel.Info)
            {
                this.InfoFormat(formatProvider, format, args);
                return;
            }
            if (level >= LogLevel.Debug)
            {
                this.DebugFormat(formatProvider, format, args);
            }
        }
    }
}
