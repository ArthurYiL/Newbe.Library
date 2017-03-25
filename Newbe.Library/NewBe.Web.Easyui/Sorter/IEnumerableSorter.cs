using System.Collections.Generic;
using System.Linq;

namespace NewBe.Web.Easyui.Sorter
{
    public interface IEnumerableSorter<T> : IEasyuiSorter
    {
        IOrderedEnumerable<T> Sort(IEnumerable<T> source);
    }
}