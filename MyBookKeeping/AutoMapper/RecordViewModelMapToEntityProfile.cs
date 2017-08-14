using AutoMapper;
using MyBookKeeping.Models;
using MyBookKeeping.Models.ViewModels;

namespace MyBookKeeping.AutoMapper
{
    public class RecordViewModelMapToEntityProfile : Profile
    {
        public override string ProfileName => "RecordViewModelMapToEntity";

        public RecordViewModelMapToEntityProfile( )
        {
            CreateMap<AccountBook, RecordViewModel>( )
                .ForMember( x => x.Amount, y => y.MapFrom( s => s.Amounttt ) )
                .ForMember( x => x.Category, y => y.MapFrom( s => s.Categoryyy == 0 ? "收入" : "支出" ) )
                .ForMember( x => x.Date, y => y.MapFrom( s => s.Dateee ) );
        }
    }
}