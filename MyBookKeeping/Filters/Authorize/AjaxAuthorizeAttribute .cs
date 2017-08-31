using System.Web.Mvc;

namespace MyBookKeeping.Filters.Authorize
{
    public sealed class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest( AuthorizationContext context )
        {
            if ( context.HttpContext.Request.IsAjaxRequest( ) )
            {
                var urlHelper = new UrlHelper( context.RequestContext );
                context.HttpContext.Response.StatusCode = 403;
                context.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "NotAuthorized",
                        LogOnUrl = urlHelper.Action( "LogIn", "Account" )
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                base.HandleUnauthorizedRequest( context );
            }
        }
    }
}