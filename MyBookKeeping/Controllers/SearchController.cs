using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using MyBookKeeping.CustomResults;
using MyBookKeeping.Filters;
using MyBookKeeping.Models;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;
using Newtonsoft.Json;
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
        public ActionResult AjaxPosts( SearchModel input )
        {
            if ( ModelState.IsValid )
            {
                const int page = 1;
                var pagedList = getIPagedList( page, input );
                return PartialView( "_IndexPartial", pagedList );
            }

            return JsonNotFoundResult( );
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
        public ActionResult RenderAjaxPartialView( int? page, int? year, int? month )
        {
            if ( year == null || month == null )
                return JsonNotFoundResult( );

            page = page ?? 1;
            var pagedList = getIPagedList( page.Value, new SearchModel { Year = year.Value, Month = month.Value } );
            return PartialView( "_IndexPartial", pagedList );
        }

        [Route( "skilltree/{year:int:min( 1 )}/{month:int:min(1):max(12)}" )]
        [AllowAnonymous]
        public ActionResult SearchByUrl( int year, int month )
        {
            const int page = 1;
            var pagedList = getIPagedList( page, new SearchModel { Year = year, Month = month } );

            if ( pagedList.Count == 0 )
                return JsonNotFoundResult( );

            ViewData[ "Year" ] = year;
            ViewData[ "Month" ] = month;

            return View( pagedList );
        }

        private static JsonNetResult JsonNotFoundResult( )
        {
            var jsonNetResult = new JsonNetResult( );
            jsonNetResult.Formatting = Formatting.Indented;
            jsonNetResult.Data = "找不到資料 !!";
            return jsonNetResult;
        }

        private IPagedList<RecordViewModel> getIPagedList( int page, SearchModel input )
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