using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyBookKeeping.Filters;
using MyBookKeeping.Filters.Authorize;
using MyBookKeeping.Models;
using MyBookKeeping.Models.DataPostModels;
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

        [HttpPost]
        [AjaxAuthorize( Roles = "Admin" )]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxPosts( AccountRecord input )
        {
            if ( ModelState.IsValid )
            {
                var accountbook = Mapper.Map<AccountBook>( input );
                _recordService.createNewRecord( accountbook );
                _recordService.save( );
            }

            return RedirectToAction( "RenderAjaxPartialView" );
        }

        [Authorize( Roles = "Admin" )]
        public ActionResult Edit( Guid recordId )
        {
            return RedirectToAction( "Edit", "Admin", new { area = "Admin", recordId } );
        }

        [AllowAnonymous]
        public ActionResult Index( int? page )
        {
            return View( );
        }

        [AjaxOnly]
        [AllowAnonymous]
        public ActionResult RenderAjaxPartialView( int? page )
        {
            page = page ?? 1;
            var pagedList = getIPagedList( page.Value );
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
    }
}