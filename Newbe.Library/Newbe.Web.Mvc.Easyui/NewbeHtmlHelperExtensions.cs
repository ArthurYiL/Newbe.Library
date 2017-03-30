#if NET452

using System;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui
{
    public static class NewbeHtmlHelperExtensions
    {
        public static INewbeHtmlHelper NewBe(this HtmlHelper helper)
        {
            throw new NotImplementedException();
        }

        public static INewbeHtmlHelper<TModel> NewBe<TModel>(this HtmlHelper helper, TModel model)
            where TModel : class
        {
            throw new NotImplementedException();
        }

        public static INewbeHtmlHelper<TModel> NewBe<TModel>(this HtmlHelper helper) where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}

#endif