using AutoMapper;
using MyBookKeeping.AutoMapper;
using MyBookKeeping.Models;
using MyBookKeeping.Models.ViewModels;

namespace MyBookKeeping.App_Start
{
    public class AutoMapperConfig
    {
        public static void configure( )
        {
            Mapper.Initialize( x => x.AddProfile<RecordViewModelMapToEntityProfile>( ) );
        }
    }
}