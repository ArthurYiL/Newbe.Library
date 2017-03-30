#if NET452

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newbe.Web.Mvc.Easyui.Options;

namespace Newbe.Web.Mvc.Easyui.Datagrid.Extensions
{
    public static class EasyuiDatagridExtensions
    {
        public static IEasyuiDatagridHtmlHelper<TModel> Datagrid<TModel>(
            this IEasyuiHtmlHelper<TModel> easyuiHtmlHelper, EasyuiDatagridOptions options = null) where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IEasyuiDatagridHtmlHelper<TModel> Datagrid<TModel>(
            this IEasyuiHtmlHelper<TModel> easyuiHtmlHelper, out string id, EasyuiDatagridOptions options = null)
            where TModel : class
        {
            throw new NotImplementedException();
        }


        public static MvcHtmlString Column<TModel>(
            this IEasyuiDatagridHtmlHelper<TModel> easyuiDatagridHtmlHelper,
            EasyuiDatagridColumnOptions options = null)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static MvcHtmlString ColumnFor<TModel, TKey>(
            this IEasyuiDatagridHtmlHelper<TModel> easyuiDatagridHtmlHelper, Expression<Func<TModel, TKey>> expression,
            EasyuiDatagridColumnOptions options = null)
            where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}

#endif