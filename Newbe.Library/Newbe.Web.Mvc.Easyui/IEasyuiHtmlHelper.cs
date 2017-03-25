using System;

namespace Newbe.Web.Mvc.Easyui
{
    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiHtmlHelper
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IEasyuiHtmlHelper<TModel> : IEasyuiHtmlHelper where TModel : class
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiInlineHtmlHelper : IEasyuiHtmlHelper
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IEasyuiInlineHtmlHelper<TModel> : IEasyuiHtmlHelper<TModel> where TModel : class
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiHtmlContainerHelper : IEasyuiHtmlHelper, IDisposable
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IEasyuiHtmlContainerHelper<TModel> : IEasyuiHtmlContainerHelper, IEasyuiHtmlHelper<TModel>
        where TModel : class
    {
    }
}