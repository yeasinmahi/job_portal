using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JobPortal
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            if (Application["hits"] == null)
            {
                Application["hits"] = 0;
            }
            
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started  
            Application.Lock();
            Application["hits"] = (int)Application["hits"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.   
            // Note: The Session_End event is raised only when the sessionstate mode  
            // is set to InProc in the Web.config file. If session mode is set to StateServer   
            // or SQLServer, the event is not raised.  
            Application.Lock();
            Application["hits"] = (int)Application["hits"] - 1;
            Application.UnLock();
        }

    }
}
