using System.ComponentModel;

namespace MyBookKeeping.Models.ViewModels
{
    public class SearchViewModel
    {
        [DisplayName( "月份" )]
        public int Month { get; set; }

        [DisplayName( "年份" )]
        public int Year { get; set; }
    }
}