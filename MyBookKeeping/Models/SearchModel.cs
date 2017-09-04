using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBookKeeping.Models
{
    public class SearchModel
    {
        [Required( ErrorMessage = "你就沒選月份啊" )]
        [DisplayName( "月份" )]
        public int Month { get; set; }

        [Required( ErrorMessage = "選個你想看的年份唄" )]
        [DisplayName( "年份" )]
        public int Year { get; set; }
    }
}