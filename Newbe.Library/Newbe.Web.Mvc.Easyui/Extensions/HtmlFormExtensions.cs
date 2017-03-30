using System;

namespace Newbe.Web.Mvc.Easyui
{
    public static class HtmlFormExtensions
    {
        public static IHtmlFormHelper<TModel> Form<TModel>(this INewbeHtmlHelper<TModel> newbeHtmlHelper)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static IHtmlFormHelper Form(this INewbeHtmlHelper newbeHtmlHelper)
        {
            throw new NotImplementedException();
        }
    }
}