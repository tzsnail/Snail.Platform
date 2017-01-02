namespace MassTransit.NLogger
{
    using System.Xml;
    using HostLogger = MassTransit.Logging.Logger;
    using LogManager = NLog.LogManager;
    using ILogWriter = MassTransit.Logging.ILog;
    using ILogWriterFactory = MassTransit.Logging.ILogger;

    public class NLogWriterFactory : ILogWriterFactory
    {
        public ILogWriter Get(string name)
        {
            return new NLogWriter(LogManager.GetLogger(name));
        }
        public void Shutdown()
        {
            LogManager.Shutdown();
        }

        public static void Use()
        {
            if (LogManager.GetCurrentClassLogger().Factory.Configuration == null)
                HostLogger.UseLogger(new MassTransit.Logging.Tracing.TraceLogger());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFileName"></param>
        public static void Use(string configFileName, bool ThrowExceptions = false)
        {
            LogManager.ThrowConfigExceptions = ThrowExceptions;
            LogManager.ThrowExceptions = ThrowExceptions;

            var _config = new NLog.Config.XmlLoggingConfiguration(configFileName, true);
            LogManager.Configuration = _config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public static void Use(XmlReader reader, bool ThrowExceptions = false)
        {
            LogManager.ThrowConfigExceptions = ThrowExceptions;
            LogManager.ThrowExceptions = ThrowExceptions;

            var _config = new NLog.Config.XmlLoggingConfiguration(reader, null);
            LogManager.Configuration = _config;
            HostLogger.UseLogger(new NLogWriterFactory());
        }
    }
}

