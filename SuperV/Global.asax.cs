using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuperV
{
    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            DashboardConfig.RegisterService(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SQLDependencyConfig.Start();

        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SQLDependencyConfig.Stop();
        }
    }
}
