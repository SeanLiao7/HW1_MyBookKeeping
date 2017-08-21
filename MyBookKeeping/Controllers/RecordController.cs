using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookKeeping.Models;
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

        public ActionResult Index( int? page )
        {
            //var items = new List<SelectListItem>( );

            //foreach ( var item in Enumerable.Range( 1, 10 ) )
            //{
            //    items.Add( new SelectListItem( )
            //    {
            //        Text = Catego
            //        Value = item.ToString( )
            //    } );
            //}
            //ViewData[ "dr" ] = items;
            return View( );
        }

        [HttpPost]
        public ActionResult NewPost( AccountRecord input )
        {
            var accountbook = Mapper.Map<AccountBook>( input );
            _recordService.createNewRecord( accountbook );
            //_recordService.save( );
            return RedirectToAction( "Index" );
        }

        [ChildActionOnly]
        public ActionResult RenderPosts( int? page )
        {
            page = page ?? 1;
            var pagedList = getIPagedList( page.Value );
            return PartialView( "_IndexPartial", pagedList );
        }

        private IPagedList<RecordViewModel> getIPagedList( int page )
        {
            return _recordService.getRecords( )
                                 .OrderBy( x => x.Dateee )
                                 .ProjectTo<RecordViewModel>( )
                                 .ToPagedList( page, _pageSize );
        }
    }
}