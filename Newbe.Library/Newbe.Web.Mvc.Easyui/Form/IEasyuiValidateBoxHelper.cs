namespace Newbe.Web.Mvc.Easyui.Form
{
    public interface IEasyuiValidateBoxHelper : IEasyuiInlineHtmlHelper
    {
    }

    public interface IEasyuiValidateBoxHelper<TModel> : IEasyuiInlineHtmlHelper<TModel> where TModel : class
    {
    }
}