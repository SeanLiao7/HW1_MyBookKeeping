using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;
using PagedList;

namespace MyBookKeeping.Controllers
{
    public class RecordController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly RecordService _recordService;

        public RecordController( )
        {
            var unitOfWork = new EFUnitOfWork( );
            _recordService = new RecordService( unitOfWork );
        }

        public ActionResult Index( int page = 1 )
        {
            page = page < 1 ? 1 : page;
            var pagedList = getIPagedList( page );
            return View( pagedList );
        }

        private IPagedList<RecordViewModel> getIPagedList( int page )
        {
            return _recordService.getAll( )
                                 .OrderBy( x => x.Dateee )
                                 .ProjectTo<RecordViewModel>( )
                                 .ToPagedList( page, _pageSize );
        }
    }
}