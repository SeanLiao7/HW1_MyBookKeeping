using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using MyBookKeeping.CustomResults;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;

namespace MyBookKeeping.Controllers
{
    public class FeedsController : Controller
    {
        private readonly RecordService _recordService;

        public FeedsController( )
        {
            var unitOfWork = new EFUnitOfWork( );
            _recordService = new RecordService( unitOfWork );
        }

        public ActionResult Index( )
        {
            var feed = this.getFeedData( );
            return new RssResult( feed );
        }

        private SyndicationFeed getFeedData( )
        {
            var feed = new SyndicationFeed(
                "我的記帳本",
                "收支RSS！",
                new Uri( Url.Action( "Index", "Feeds", null, "http" ) ) );

            var items = new List<SyndicationItem>( );

            var records = _recordService.getRecords( )
                .OrderByDescending( x => x.Dateee );

            foreach ( var record in records )
            {
                var item = new SyndicationItem(
                    record.Categoryyy.ToString( ),
                    record.Amounttt.ToString( ),
                    new Uri( Url.Action( "Detail", "Record", new { recordId = record.Id }, "http" ) ),
                    "ID",
                    DateTime.Now );

                items.Add( item );
            }

            feed.Items = items;
            return feed;
        }
    }
}