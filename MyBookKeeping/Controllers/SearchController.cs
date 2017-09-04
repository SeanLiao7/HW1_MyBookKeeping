using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using MyBookKeeping.Filters;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;
using PagedList;

namespace MyBookKeeping.Controllers
{
    public class SearchController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly RecordService _recordService;

        public SearchController( )
        {
            var unitOfWork = new EFUnitOfWork( );
            _recordService = new RecordService( unitOfWork );
        }

        [AjaxOnly]
        [AllowAnonymous]
        public ActionResult AjaxPosts( SearchViewModel input )
        {
            const int page = 1;
            var pagedList = getIPagedList( page, input );
            return PartialView( "_IndexPartial", pagedList );
        }

        [AllowAnonymous]
        public ActionResult Index( )
        {
            var minAndMaxYear = getMinAndMaxYear( );

            ViewData[ "year" ] = new SelectList(
                Enumerable.Range( minAndMaxYear.min, minAndMaxYear.max - minAndMaxYear.min + 1 ) );
            ViewData[ "month" ] = new SelectList( Enumerable.Range( 1, 12 ) );

            return View( );
        }

        [AjaxOnly]
        [AllowAnonymous]
        public ActionResult RenderAjaxPartialView( int? page, int year, int month )
        {
            page = page ?? 1;
            var pagedList = getIPagedList( page.Value, new SearchViewModel { Year = year, Month = month } );
            return PartialView( "_IndexPartial", pagedList );
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult RenderParialView( )
        {
            const int firstPage = 1;
            var pagedList = getIPagedList( firstPage );
            return PartialView( "_IndexPartial", pagedList );
        }

        private IPagedList<RecordViewModel> getIPagedList( int page )
        {
            return _recordService.getRecords( )
                .OrderBy( x => x.Dateee )
                .ThenBy( x => x.Id )
                .ProjectTo<RecordViewModel>( )
                .ToPagedList( page, _pageSize );
        }

        private IPagedList<RecordViewModel> getIPagedList( int page, SearchViewModel input )
        {
            return _recordService.getRecords( )
                .Where( x => x.Dateee.Year == input.Year && x.Dateee.Month == input.Month )
                .OrderBy( x => x.Dateee )
                .ThenBy( x => x.Id )
                .ProjectTo<RecordViewModel>( )
                .ToPagedList( page, _pageSize );
        }

        private (int min, int max) getMinAndMaxYear( )
        {
            var minYear = _recordService.getRecords( )
                .Min( x => x.Dateee.Year );

            var maxYear = _recordService.getRecords( )
                .Max( x => x.Dateee.Year );

            return (minYear, maxYear);
        }
    }
}