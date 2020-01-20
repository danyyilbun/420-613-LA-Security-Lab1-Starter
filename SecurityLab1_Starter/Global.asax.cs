using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
           
            //System.Diagnostics.Debug.WriteLine();
            //        Response.Redirect("~/Home/Index");
            LogingUtil lg = new LogingUtil();
            lg.LogEvent(Server.GetLastError(),EventLogEntryType.Error);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry( " LOGGED ERROR " + DateTime.Now, EventLogEntryType.Information, 101, 1);
            }

        }
    }
}
