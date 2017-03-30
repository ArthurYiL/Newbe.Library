using System;

namespace Newbe.Web.Mvc.Easyui
{
    public interface INewbeHtmlHelper
    {
    }

    public interface INewbeHtmlHelper<TModel> : INewbeHtmlHelper where TModel : class
    {
    }


    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface INewbeInlineHtmlHelper : INewbeHtmlHelper
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface INewbeInlineHtmlHelper<TModel> : INewbeInlineHtmlHelper, INewbeHtmlHelper<TModel>
        where TModel : class
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface INewbeHtmlContainerHelper : INewbeHtmlHelper, IDisposable
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface INewbeHtmlContainerHelper<TModel> : INewbeHtmlContainerHelper, INewbeHtmlHelper<TModel>
        where TModel : class
    {
    }


    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiHtmlHelper : INewbeHtmlHelper
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IEasyuiHtmlHelper<TModel> : IEasyuiHtmlHelper, INewbeHtmlHelper<TModel> where TModel : class
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiInlineHtmlHelper : INewbeInlineHtmlHelper
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IEasyuiInlineHtmlHelper<TModel> : IEasyuiInlineHtmlHelper, IEasyuiHtmlHelper<TModel>
        where TModel : class
    {
    }

    /// <summary>
    /// HtmlHelper for Easyui
    /// </summary>
    public interface IEasyuiHtmlContainerHelper : INewbeHtmlContainerHelper
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