#if NET452


using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newbe.Web.Mvc.Easyui.Options;

namespace Newbe.Web.Mvc.Easyui.Form.Extensions
{
    public static class EasyuiFormControlExtensions
    {
        public static MvcHtmlString ValidateBox(this IEasyuiHtmlHelper easyuiHtmlHelper,
            EasyuiValidateBoxOptions options = null, object htmlAttribues = null)
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString ValidateBoxFor<TModel, TKey>(this IEasyuiHtmlHelper<TModel> easyuiHtmlHelper,
            Expression<Func<TModel, TKey>> expression,
            EasyuiValidateBoxOptions options = null, object htmlAttribues = null)
            where TModel : class
        {
            throw new NotImplementedException();
        }


        public static MvcHtmlString ValidateBoxFor<TModel, TKey>(this IEasyuiHtmlHelper<TModel> easyuiHtmlHelper,
            Expression<Func<TModel, TKey>> expression, out string id,
            EasyuiValidateBoxOptions options = null, object htmlAttribues = null)
            where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}

#endif