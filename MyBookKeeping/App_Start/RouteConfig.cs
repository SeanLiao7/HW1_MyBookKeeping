using System.Web.Mvc;
using System.Web.Routing;

namespace MyBookKeeping
{
    public class RouteConfig
    {
        public static void RegisterRoutes( RouteCollection routes )
        {
            //想忽略的副檔名
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );
            routes.IgnoreRoute( "{resource}.ashx/{*pathInfo}" );

            //加上這行可以強制 url 小寫
            routes.LowercaseUrls = true;

            //註冊 Attribute Route
            routes.MapMvcAttributeRoutes( );

            routes.MapRoute(
                name: "Record",
                url: "skilltree",
                defaults: new { controller = "record", action = "index" },
                constraints: new { controller = @"record" }

            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Record", action = "Index", page = UrlParameter.Optional },
                namespaces: new[ ] { "MyBookKeeping.Controllers" }
            );
        }
    }
}