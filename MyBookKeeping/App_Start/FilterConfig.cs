using System.Web.Mvc;

namespace MyBookKeeping
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute( ) );
        }
    }
}