#if NET452

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui
{
    public static class EasyuiHtmlHelperExtensions
    {
        public static IEasyuiHtmlHelper Easyui(this HtmlHelper helper)
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this HtmlHelper helper, TModel model)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this HtmlHelper helper) where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}

#endif