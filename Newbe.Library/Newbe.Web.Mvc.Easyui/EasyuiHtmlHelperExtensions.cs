using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Web.Mvc.Easyui;

namespace Newbe.Web.Mvc.Easyui
{
    public static class EasyuiHtmlHelperExtensions
    {
        public static IEasyuiHtmlHelper Easyui(this INewbeHtmlHelper helper)
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this INewbeHtmlHelper helper, TModel model)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this INewbeHtmlHelper helper)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this INewbeHtmlHelper<TModel> helper, TModel model)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IEasyuiHtmlHelper<TModel> Easyui<TModel>(this INewbeHtmlHelper<TModel> helper)
            where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}