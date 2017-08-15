using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MyBookKeeping.Controllers;
using MyBookKeeping.Models;
using MyBookKeeping.Repositories;
using MyBookKeeping.Service;

namespace MyBookKeeping.App_Start
{
    public class AutofacConfig
    {
        public static void buildUp( )
        {
            var builder = new ContainerBuilder( );
            builder.RegisterControllers( Assembly.GetExecutingAssembly( ) );

            var connectionString = ConfigurationManager.ConnectionStrings[ "SkillTreeHomeworkEntites" ].ConnectionString;

            builder.RegisterType<DbContextFactory>( )
                   .WithParameter( "connectionString", connectionString )
                   .AsImplementedInterfaces( )
                   .InstancePerRequest( );

            builder.RegisterGeneric( typeof( Repository<> ) ).As( typeof( IRepository<> ) );
            builder.RegisterType<EFUnitOfWork>( ).AsImplementedInterfaces( );
            builder.RegisterType<RecordService>( ).AsImplementedInterfaces( );

            var container = builder.Build( );

            // 解析容器內的型別
            //AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver( container );
            AutofacDependencyResolver resolver = new AutofacDependencyResolver( container );

            // 建立相依解析器
            //GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            DependencyResolver.SetResolver( resolver );
        }
    }
}