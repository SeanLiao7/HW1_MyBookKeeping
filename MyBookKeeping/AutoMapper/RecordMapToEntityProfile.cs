using AutoMapper;
using MyBookKeeping.Models;
using MyBookKeeping.Models.DataPostModels;
using MyBookKeeping.Models.ViewModels;

namespace MyBookKeeping.AutoMapper
{
    public class RecordMapToEntityProfile : Profile
    {
        public override string ProfileName => "RecordViewModelMapToEntity";

        public RecordMapToEntityProfile( )
        {
            CreateMap<AccountBook, RecordViewModel>( )
                .ForMember( x => x.Amount, y => y.MapFrom( s => ( decimal ) s.Amounttt ) )
                .ForMember( x => x.Category, y => y.MapFrom( s => ( CategoryEnum ) s.Categoryyy ) )
                .ForMember( x => x.Date, y => y.MapFrom( s => s.Dateee ) )
                .ForMember( x => x.RecordId, y => y.MapFrom( s => s.Id ) )
                .ForMember( x => x.Remark, y => y.MapFrom( s => s.Remarkkk ) );

            CreateMap<AccountRecord, AccountBook>( )
                .ForMember( x => x.Amounttt, y => y.MapFrom( s => ( int ) s.Amount ) )
                .ForMember( x => x.Categoryyy, y => y.MapFrom( s => ( int ) s.Category ) )
                .ForMember( x => x.Dateee, y => y.MapFrom( s => s.Date ) )
                .ForMember( x => x.Remarkkk, y => y.MapFrom( s => s.Remark ) )
                .ForMember( x => x.Id, y => y.Ignore( ) );

            CreateMap<AccountBook, AccountRecord>( )
                .ForMember( x => x.Amount, y => y.MapFrom( s => ( decimal ) s.Amounttt ) )
                .ForMember( x => x.Category, y => y.MapFrom( s => ( CategoryEnum ) s.Categoryyy ) )
                .ForMember( x => x.Date, y => y.MapFrom( s => s.Dateee ) )
                .ForMember( x => x.Remark, y => y.MapFrom( s => s.Remarkkk ) );
        }
    }
}