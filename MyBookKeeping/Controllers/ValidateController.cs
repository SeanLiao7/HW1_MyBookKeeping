using System;
using System.Web.Mvc;

namespace MyBookKeeping.Controllers
{
    public class ValidateController : Controller
    {
        public ActionResult AmountValidate( decimal amount )
        {
            var isValidate = amount % 1 == 0 && amount >= 1 && amount <= int.MaxValue;
            return Json( isValidate, JsonRequestBehavior.AllowGet );
        }

        public ActionResult DateValidate( DateTime date )
        {
            var isValidate = date.Date <= DateTime.Now.Date;
            return Json( isValidate, JsonRequestBehavior.AllowGet );
        }
    }
}