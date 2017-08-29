using System;
using System.Web.Mvc;
using MyBookKeeping.Extensions;

namespace MyBookKeeping.Helper
{
    public static class HelperExtensions
    {
        public static MvcHtmlString getGreetingString( this HtmlHelper helper, string userName )
        {
            return MvcHtmlString.Create( "Hello " + userName + "!" );
        }

        public static MvcHtmlString showDisplayNameByEnumValue( this HtmlHelper helper, Enum enumValue )
        {
            return MvcHtmlString.Create( enumValue.getDisplayName( ) );
        }
    }
}