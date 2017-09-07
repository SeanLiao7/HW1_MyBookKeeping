using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MyBookKeeping.App_Start;

namespace MyBookKeeping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start( )
        {
            #region 提高效能-移除不必要的顯示引擎

            ViewEngines.Engines.Clear( );
            ViewEngines.Engines.Add( new CSharpRazorViewEngine( ) );

            #endregion 提高效能-移除不必要的顯示引擎

            #region 資安議題-隱藏MVC版本

            MvcHandler.DisableMvcResponseHeader = true;

            #endregion 資安議題-隱藏MVC版本

            #region ModelBinder-字串自動Trim

            ModelBinders.Binders.Add( typeof( string ), new TrimStringModelBinder( ) );

            #endregion ModelBinder-字串自動Trim

            AutoMapperConfig.configure( );
            AreaRegistration.RegisterAllAreas( );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
        }

        private void Application_AuthenticateRequest( object sender, EventArgs e )
        {
            if ( Request.IsAuthenticated )
            {
                // 先取得該使用者的 FormsIdentity
                var id = ( FormsIdentity ) User.Identity;

                // 再取出使用者的 FormsAuthenticationTicket
                var ticket = id.Ticket;

                // 將儲存在 FormsAuthenticationTicket 中的角色定義取出，並轉成字串陣列
                var roles = ticket.UserData.Split( new[ ] { "," }, StringSplitOptions.RemoveEmptyEntries );

                // 指派角色到目前這個 HttpContext 的 User 物件
                Context.User = new GenericPrincipal( Context.User.Identity, roles );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Class TrimStringModelBinder.
        /// </summary>
        /// <seealso cref="T:System.Web.Mvc.DefaultModelBinder" />
        public class TrimStringModelBinder : DefaultModelBinder
        {
            public override object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext )
            {
                var value = base.BindModel( controllerContext, bindingContext );
                if ( value is string )
                    return ( value as string ).Trim( );
                return value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Class CSharpRazorViewEngine.
        /// </summary>
        /// <seealso cref="T:System.Web.Mvc.RazorViewEngine" />
        internal class CSharpRazorViewEngine : RazorViewEngine
        {
            public CSharpRazorViewEngine( )
            {
                AreaViewLocationFormats = new[ ]
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };
                AreaMasterLocationFormats = new[ ]
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };
                AreaPartialViewLocationFormats = new[ ]
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                };

                ViewLocationFormats = new[ ]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };
                MasterLocationFormats = new[ ]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml",
                };
                PartialViewLocationFormats = new[ ]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml"
                };

                FileExtensions = new[ ]
                {
                    "cshtml"
                };
            }
        }
    }
}