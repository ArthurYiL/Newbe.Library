using System.Linq;

namespace NewBe.Web.Easyui.Sorter
{
    public interface IQueryableSorter<T> : IEasyuiSorter
    {
        IOrderedQueryable<T> Sort(IQueryable<T> source);
    }
}