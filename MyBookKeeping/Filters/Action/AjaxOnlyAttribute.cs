using System.Web.Mvc;

namespace MyBookKeeping.Filters
{
    public sealed class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            if ( !filterContext.HttpContext.Request.IsAjaxRequest( ) )
            {
                filterContext.Result = new HttpNotFoundResult( );
            }
        }
    }
}