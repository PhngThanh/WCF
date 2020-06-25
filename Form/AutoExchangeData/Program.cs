using System;
//using UniLogLibFramework.Library;

namespace AutoExchangeData
{
    static class Program
    {
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //public static LogMonitor _log = new LogMonitor();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //log4net.Config.XmlConfigurator.Configure();

#if DEBUG
            //log.Info("Program");
            try
            {
                //log.Info("Service");
                Service1 myService = new Service1();
                myService.OnDebug();
            }
            catch (Exception ex)
            {
                //log.Error("Main - " + ex);
                //_log.SendLogError(ex);
            }


#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
