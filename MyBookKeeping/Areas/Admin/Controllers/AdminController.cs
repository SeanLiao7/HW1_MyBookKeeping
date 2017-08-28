using System;
using System.Web.Mvc;
using AutoMapper;
using MyBookKeeping.Models;
using MyBookKeeping.Models.DataPostModels;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;

namespace MyBookKeeping.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly RecordService _recordService;

        public AdminController( )
        {
            _recordService = new RecordService( new EFUnitOfWork( ) );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Guid recordId, AccountRecord accountRecord )
        {
            if ( ModelState.IsValid )
            {
                var updatedRecord = getUpdatedRecord( recordId, accountRecord );
                _recordService.updateRecord( updatedRecord );
                _recordService.save( );

                return RedirectToAction( "Index", "Record", new { area = "" } );
            }

            return RedirectToAction( "Index", new { recordId } );
        }

        public ActionResult Index( Guid recordId )
        {
            var record = _recordService.getRecordById( recordId );
            var accountRecord = Mapper.Map<AccountRecord>( record );

            return View( accountRecord );
        }

        private AccountBook getUpdatedRecord( Guid recordId, AccountRecord accountRecord )
        {
            var updateRecord = _recordService.getRecordById( recordId );
            updateRecord.Dateee = accountRecord.Date;
            updateRecord.Amounttt = ( int ) accountRecord.Amount;
            updateRecord.Categoryyy = ( int ) accountRecord.Category;
            updateRecord.Remarkkk = accountRecord.Remark;

            return updateRecord;
        }
    }
}