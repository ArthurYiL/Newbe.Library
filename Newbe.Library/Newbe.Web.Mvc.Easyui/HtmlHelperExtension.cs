
#if NET452
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui
{
    public static class HtmlHelperExtension
    {
        internal static string EvalString(this HtmlHelper htmler, string key)
        {
            return Convert.ToString(htmler.ViewData.Eval(key), (IFormatProvider) CultureInfo.CurrentCulture);
        }

        internal static string EvalString(this HtmlHelper htmler, string key, string format)
        {
            return Convert.ToString(htmler.ViewData.Eval(key, format), (IFormatProvider) CultureInfo.CurrentCulture);
        }

        internal static object GetModelStateValue(this HtmlHelper htmler, string key, Type destinationType)
        {
            ModelState modelState;
            if (htmler.ViewData.ModelState.TryGetValue(key, out modelState) && modelState.Value != null)
                return modelState.Value.ConvertTo(destinationType, (CultureInfo) null);
            return (object) null;
        }

        internal static bool EvalBoolean(this HtmlHelper htmler, string key)
        {
            return Convert.ToBoolean(htmler.ViewData.Eval(key), (IFormatProvider) CultureInfo.InvariantCulture);
        }

        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}

#endif