using System;
using System.Collections.Generic;
using System.Linq;

namespace NewBe.Web.Easyui.Sorter
{
    internal class EnumerableEasyuiSorter<T> : IEnumerableSorter<T>
    {
        private readonly ISotyByPropertyResolver<T> _sotyByPropertyResolver;

        public EnumerableEasyuiSorter(IEasyuiSorter easyuiSorter, ISotyByPropertyResolver<T> sotyByPropertyResolver)
        {
            _sotyByPropertyResolver = sotyByPropertyResolver;
            SortBy = easyuiSorter.SortBy;
            Order = easyuiSorter.Order;
        }

        public string SortBy { get; set; }
        public SortOrder Order { get; set; }

        public IOrderedEnumerable<T> Sort(IEnumerable<T> source)
        {
            var property = _sotyByPropertyResolver.ResolveSortByProperty(SortBy);
            var re = Order == SortOrder.Asc
                ? source.OrderBy(x => property.GetValue(x))
                : source.OrderByDescending(x => property.GetValue(x));
            return re;
        }
    }
}