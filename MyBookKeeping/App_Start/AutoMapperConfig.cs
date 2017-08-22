using AutoMapper;
using MyBookKeeping.AutoMapper;

namespace MyBookKeeping.App_Start
{
    public class AutoMapperConfig
    {
        public static void configure( )
        {
            Mapper.Initialize( x => x.AddProfile<RecordMapToEntityProfile>( ) );
            Mapper.AssertConfigurationIsValid( );
        }
    }
}