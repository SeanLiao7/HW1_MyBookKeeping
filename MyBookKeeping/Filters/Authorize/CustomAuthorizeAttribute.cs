using System.Web.Mvc;

namespace MyBookKeeping.Filters.Authorize
{
    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string ActionName { get; set; }
        public string Area { get; set; }
        public string ControllerName { get; set; }

        public override void OnAuthorization( AuthorizationContext filterContext )
        {
            // If they are authorized, handle accordingly
            if ( this.AuthorizeCore( filterContext.HttpContext ) )
            {
                base.OnAuthorization( filterContext );
            }

            // Otherwise redirect to your specific authorized area
            else
            {
                var url = new UrlHelper( filterContext.RequestContext ).Action(
                    ActionName,
                    ControllerName,
                    new { area = Area } );

                filterContext.Result = new RedirectResult( url );
            }
        }
    }
}