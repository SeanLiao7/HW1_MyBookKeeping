using System.Web.Mvc;

namespace ValidateSample.Filters.Validation
{
    public sealed class RemotePlusAttribute : RemoteAttribute
    {
        public RemotePlusAttribute( string action, string controller, string area )
            : base( action, controller, area )
        {
            this.RouteData[ "area" ] = area;
        }
    }
}