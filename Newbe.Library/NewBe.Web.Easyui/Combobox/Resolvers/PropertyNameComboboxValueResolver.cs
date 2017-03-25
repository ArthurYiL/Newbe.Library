using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal class PropertyNameComboboxValueResolver : IComboboxValueResolver
    {
        private static readonly string[] TextPropertyNameMatcher = {"Id", "Value"};
        private PropertyInfo _valuePropertyInfo;
        int IComboboxValueResolver.Order => 2;

        bool IComboboxValueResolver.CanResolve<T>(T item)
        {
            var props = typeof(T).GetRuntimeProperties().ToList();
            foreach (var k in TextPropertyNameMatcher)
            {
                if (_valuePropertyInfo != null)
                {
                    break;
                }
                _valuePropertyInfo = props.FirstOrDefault(x => x.Name.Contains(k));
            }
            return _valuePropertyInfo != null;
        }

        string IComboboxValueResolver.ResolveValue<T>(T item)
        {
            return item == null ? string.Empty : _valuePropertyInfo?.GetValue(item)?.ToString();
        }
    }
}