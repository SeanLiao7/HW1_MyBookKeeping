using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper.Configuration.Conventions;

namespace MyBookKeeping
{
    public class RouteConfig
    {
        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Record", action = "Index", id = UrlParameter.Optional },
                namespaces: new[ ] { "MyBookKeeping.Controllers" }
            );
        }
    }
}