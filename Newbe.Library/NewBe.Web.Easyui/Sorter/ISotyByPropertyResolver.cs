using System.Reflection;

namespace NewBe.Web.Easyui.Sorter
{
    internal interface ISotyByPropertyResolver<T>
    {
        PropertyInfo ResolveSortByProperty(string sortBy);
    }
}