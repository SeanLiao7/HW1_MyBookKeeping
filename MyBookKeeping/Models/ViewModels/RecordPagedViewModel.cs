using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPaging;

namespace MyBookKeeping.Models.ViewModels
{
    public class RecordPagedViewModel
    {
        public int Page { get; set; } = 0;
        public IPagedList<RecordViewModel> Records { get; set; }
    }
}