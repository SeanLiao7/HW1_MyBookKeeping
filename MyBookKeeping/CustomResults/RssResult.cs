using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace MyBookKeeping.CustomResults
{
    public class RssResult : ActionResult
    {
        private SyndicationFeed _rssFeed;

        public RssResult( SyndicationFeed rssFeed )
        {
            this._rssFeed = rssFeed;
        }

        public override void ExecuteResult( ControllerContext context )
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";
            Rss20FeedFormatter formatter = new Rss20FeedFormatter( this._rssFeed );
            using ( var writer = XmlWriter.Create( context.HttpContext.Response.Output ) )
            {
                formatter.WriteTo( writer );
            }
        }
    }
}