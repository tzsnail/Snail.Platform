namespace MassTransit
{
    using System.Xml;
    using IFactoryConfigurator = MassTransit.IBusFactoryConfigurator;


    /// <summary>
    /// Extensions for configuring MassTransit for NLog
    /// </summary>
    public static class NLogConfigurationExtensions
    {
        
        /// <summary>
        /// Specify that you want to use the NLog logging engine for logging with MassTransit.
        /// </summary>
        /// <param name="configurator"></param>
        public static void Use(this IFactoryConfigurator configurator)
        {
            NLogger.NLogWriterFactory.Use();
        }

        /// <summary>
        /// Specify that NLog should be used for logging MassTransit messages
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="configFileName">The name of the NLog xml configuration file</param>
        public static void Use(this IFactoryConfigurator configurator, string configFileName,bool ThrowExceptions = false)
        {
            NLogger.NLogWriterFactory.Use(configFileName, ThrowExceptions);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="reader"></param>
        public static void Use(this IFactoryConfigurator configurator, XmlReader reader, bool ThrowExceptions = false)
        {
            NLogger.NLogWriterFactory.Use(reader, ThrowExceptions);
        }
    }
}
