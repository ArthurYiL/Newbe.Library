namespace Newbe.Web.Mvc.Easyui
{
    public interface IHtmlFormHelper : INewbeHtmlContainerHelper
    {
    }

    public interface IHtmlFormHelper<TModel> : INewbeHtmlContainerHelper<TModel>, IHtmlFormHelper
        where TModel : class
    {
    }
}