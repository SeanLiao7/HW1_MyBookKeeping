using System.Linq;
using System.Web.Mvc;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Service;
using PagedList;

namespace MyBookKeeping.Controllers
{
    public class RecordController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly RecordService _recordService;

        public RecordController( RecordService recordService )
        {
            _recordService = recordService;
        }

        public ActionResult Index( int page = 1 )
        {
            page = page < 1 ? 1 : page;
            var pagedList = getIPagedList( page );
            return View( pagedList );
        }

        private IPagedList<RecordViewModel> getIPagedList( int page )
        {
            var records = _recordService.getAll( );
            return records.OrderBy( x => x.Date )
                          .ToPagedList( page, _pageSize );
        }
    }
}