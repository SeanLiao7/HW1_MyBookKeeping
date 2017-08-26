using System;
using System.Web.Mvc;
using System.Web.Routing;
using MyBookKeeping.App_Start;

namespace MyBookKeeping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PostAuthenticateRequest( object sender, EventArgs e )
        {
            if ( User.Identity.IsAuthenticated )
            {
                //Do stuff here
            }
        }

        protected void Application_Start( )
        {
            AutoMapperConfig.configure( );

            AreaRegistration.RegisterAllAreas( );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
        }
    }
}