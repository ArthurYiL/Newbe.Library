using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Sorter
{
    internal class SortByPropertyResolver<T> : ISotyByPropertyResolver<T>
    {
        private static readonly IEnumerable<PropertyInfo> PropertyInfos = typeof(T).GetRuntimeProperties();

        PropertyInfo ISotyByPropertyResolver<T>.ResolveSortByProperty(string sortBy)
        {
            var property =
                (PropertyInfos.FirstOrDefault(x => x.Name.Equals(sortBy, StringComparison.OrdinalIgnoreCase)) ??
                 PropertyInfos.FirstOrDefault(x => x.GetCustomAttribute<EasyuiDefaultSortByAttribute>() != null) ??
                 PropertyInfos.FirstOrDefault(x => x.Name.Contains("Id"))) ??
                PropertyInfos.First();
            return property;
        }
    }
}