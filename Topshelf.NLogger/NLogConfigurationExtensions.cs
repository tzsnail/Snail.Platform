namespace Topshelf
{
    using System.Xml;


    /// <summary>
    /// Extensions for configuring Topshelf for NLog
    /// </summary>
    public static class NLogConfigurationExtensions
    {
        /// <summary>
        /// Specify that you want to use the NLog logging engine for logging with Topshelf.
        /// </summary>
        /// <param name="configurator"></param>
        public static void UseNLog(this HostConfigurators.HostConfigurator configurator)
        {
            NLogger.NLogWriterFactory.Use();
        }

        /// <summary>
        /// Specify that NLog should be used for logging Topshelf messages
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="configFileName">The name of the NLog xml configuration file</param>
        public static void UseNlogFile(this HostConfigurators.HostConfigurator configurator, string configFileName,bool ThrowExceptions = false)
        {
            NLogger.NLogWriterFactory.UseFile(configFileName,ThrowExceptions);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="reader"></param>
        public static void UseNLogXml(this HostConfigurators.HostConfigurator configurator, XmlReader reader, bool ThrowExceptions = false)
        {
            NLogger.NLogWriterFactory.UseXml(reader, ThrowExceptions);
        }
    }
}
