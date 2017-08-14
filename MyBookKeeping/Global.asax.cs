using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyBookKeeping.App_Start;

namespace MyBookKeeping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start( )
        {
            AutoMapperConfig.configure( );

            AreaRegistration.RegisterAllAreas( );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
        }
    }
}