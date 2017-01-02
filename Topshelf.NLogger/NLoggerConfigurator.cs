namespace Topshelf.NLogger
{
    using NLog;
    using System;
    using System.Xml;
    using ILogWriterFactory = Topshelf.Logging.LogWriterFactory;

    [Serializable]
    internal class NLoggerConfigurator : Topshelf.Logging.HostLoggerConfigurator
    {
        string filename;
        XmlReader reader;

        public NLoggerConfigurator(XmlReader reader, string filename, bool ThrowExceptions = false)
        {
            this.filename = filename;
            this.reader = reader;

            LogManager.ThrowConfigExceptions = ThrowExceptions;
            LogManager.ThrowExceptions = ThrowExceptions;
        }

        public ILogWriterFactory CreateLogWriterFactory()
        {
            NLog.Config.LoggingConfiguration _config;
            try
            {
                if (!string.IsNullOrEmpty(this.filename))
                {
                    _config = new NLog.Config.XmlLoggingConfiguration(filename, true);
                    LogManager.Configuration = _config;
                }
                else if (reader != null)
                {
                    _config = new NLog.Config.XmlLoggingConfiguration(reader, null);
                    LogManager.Configuration = _config;
                }

                var config = LogManager.GetCurrentClassLogger().Factory.Configuration;
                if (config == null || config.AllTargets.Count == 0)
                    return new Logging.TraceLogWriterFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Waring : {0}",ex.Message);
                return new Logging.TraceLogWriterFactory();
            }
            return new NLogWriterFactory();
        }

        public static ILogWriterFactory Default
        {
            get
            {
                return new Logging.TraceLogWriterFactory();
            }
        }
    }
}
