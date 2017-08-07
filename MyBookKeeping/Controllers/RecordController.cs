using System.Linq;
using System.Web.Mvc;
using MvcPaging;
using MyBookKeeping.Models.ViewModels;
using MyBookKeeping.Service;

namespace MyBookKeeping.Controllers
{
    public class RecordController : Controller
    {
        private int _pageSize = 10;

        public ActionResult Index( )
        {
            var viewModel = new RecordPagedViewModel( );

            var records = new RecordService( ).getAll( );
            viewModel.Records = records
                                .OrderBy( x => x.Date )
                                .ToPagedList( viewModel.Page > 0 ? viewModel.Page - 1 : 0, _pageSize );

            return View( viewModel );
        }

        [HttpPost]
        public ActionResult Index( RecordPagedViewModel viewModel )
        {
            var records = new RecordService( ).getAll( );
            viewModel.Records = records
                                .OrderBy( x => x.Date )
                                .ToPagedList( viewModel.Page > 0 ? viewModel.Page - 1 : 0, _pageSize );

            return View( viewModel );
        }
    }
}