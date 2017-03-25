using System.Collections.Generic;
using System.Linq;
using NewBe.Web.Easyui.Sorter;

// ReSharper disable once CheckNamespace

namespace NewBe.Web.Easyui
{
    public static class EasyuiSorterExtensions
    {
        public static IEnumerable<T> EasyuiSort<T>(this IEnumerable<T> source, IEasyuiSorter sorter)
        {
            var s = new EnumerableEasyuiSorter<T>(sorter, new SortByPropertyResolver<T>());
            var re = s.Sort(source);
            return re;
        }

        public static IQueryable<T> EasyuiSort<T>(this IQueryable<T> source, IEasyuiSorter sorter)
        {
            var s = new QueryableEasyuiSorter<T>(sorter, new SortByPropertyResolver<T>());
            var re = s.Sort(source);
            return re;
        }
    }
}