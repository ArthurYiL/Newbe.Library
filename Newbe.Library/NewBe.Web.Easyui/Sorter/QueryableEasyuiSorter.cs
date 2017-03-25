using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NewBe.Web.Easyui.Sorter
{
    internal class QueryableEasyuiSorter<T> : IQueryableSorter<T>
    {
        private readonly ISotyByPropertyResolver<T> _sotyByPropertyResolver;
        private static readonly IEnumerable<PropertyInfo> PropertyInfos = typeof(T).GetRuntimeProperties();

        private static readonly IDictionary<PropertyInfo, MethodInfo> OrderAscMethodInfos =
            PropertyInfos.ToDictionary(x => x, property => (new Func
                    <IQueryable<object>, Expression<Func<object, object>>, IOrderedQueryable<object>>(
                        Queryable.OrderBy).GetMethodInfo().GetGenericMethodDefinition())
                .MakeGenericMethod(typeof(T), property.PropertyType));

        private static readonly IDictionary<PropertyInfo, MethodInfo> OrderDescMethodInfos =
            PropertyInfos.ToDictionary(x => x, property => (new Func
                    <IQueryable<object>, Expression<Func<object, object>>, IOrderedQueryable<object>>(
                        Queryable.OrderByDescending).GetMethodInfo().GetGenericMethodDefinition())
                .MakeGenericMethod(typeof(T), property.PropertyType));

        private static readonly IDictionary<PropertyInfo, Expression> PropertyExpressions =
            PropertyInfos.ToDictionary(x => x,
                property =>
                {
                    var parameterExp = Expression.Parameter(typeof(T));
                    var propertyExp = Expression.Property(parameterExp, property);
                    var lama = Expression.Lambda(propertyExp, parameterExp);
                    return (Expression) lama;
                });

        public QueryableEasyuiSorter(IEasyuiSorter easyuiSorter, ISotyByPropertyResolver<T> sotyByPropertyResolver)
        {
            _sotyByPropertyResolver = sotyByPropertyResolver;
            SortBy = easyuiSorter.SortBy;
            Order = easyuiSorter.Order;
        }

        public IOrderedQueryable<T> Sort(IQueryable<T> source)
        {
            var property = _sotyByPropertyResolver.ResolveSortByProperty(SortBy);
            var makeGenericMethod = Order == SortOrder.Asc
                ? OrderAscMethodInfos[property]
                : OrderDescMethodInfos[property];
            return (IOrderedQueryable<T>)
                source.Provider.CreateQuery<T>(Expression.Call(null,
                    makeGenericMethod,
                    new[] {source.Expression, Expression.Quote(PropertyExpressions[property])}));
        }

        public string SortBy { get; set; }
        public SortOrder Order { get; set; }
    }
}