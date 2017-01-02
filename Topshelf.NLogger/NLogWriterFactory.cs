namespace Topshelf.NLogger
{
    using System.Xml;
    using HostLogger = Topshelf.Logging.HostLogger;
    using ILogWriter = Topshelf.Logging.LogWriter;
    using ILogWriterFactory = Topshelf.Logging.LogWriterFactory;
    using LogManager = NLog.LogManager;

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

        public static void Use(bool ThrowExceptions = false)
        {
            HostLogger.UseLogger(new NLoggerConfigurator(null, null, ThrowExceptions));
        }

        public static void UseFile(string configFileName, bool ThrowExceptions = false)
        {
            HostLogger.UseLogger(new NLoggerConfigurator(null, configFileName, ThrowExceptions));
        }

        public static void UseXml(XmlReader reader, bool ThrowExceptions = false)
        {
            HostLogger.UseLogger(new NLoggerConfigurator(reader, null, ThrowExceptions));
        }
    }
}

