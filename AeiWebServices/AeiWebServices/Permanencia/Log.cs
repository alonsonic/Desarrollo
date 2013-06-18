using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeiWebServices.Permanencia
{
    public static class Log
    {
        static ILog log;
                
        static void nuevoLog()
        {
            log=log4net.LogManager.GetLogger(typeof(Log));
        }

        public static ILog LogInstanciar ()
        {
            if (log==null)
            {
                nuevoLog();
                log4net.Config.XmlConfigurator.Configure();
            }
            return log;
        }
    }
}