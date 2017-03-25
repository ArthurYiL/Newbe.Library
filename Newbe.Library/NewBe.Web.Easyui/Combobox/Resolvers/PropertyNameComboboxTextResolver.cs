using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal class PropertyNameComboboxTextResolver : IComboboxTextResolver
    {
        private static readonly string[] TextPropertyNameMatcher = {"Text", "Name"};
        private PropertyInfo _textPropertyInfo;
        int IComboboxTextResolver.Order => 2;

        bool IComboboxTextResolver.CanResolve<T>(T item)
        {
            var props = typeof(T).GetRuntimeProperties().ToList();
            foreach (var k in TextPropertyNameMatcher)
            {
                if (_textPropertyInfo != null)
                {
                    break;
                }
                _textPropertyInfo = props.FirstOrDefault(x => x.Name.Contains(k));
            }
            return _textPropertyInfo != null;
        }

        string IComboboxTextResolver.ResolveText<T>(T item)
        {
            return item == null ? string.Empty : _textPropertyInfo?.GetValue(item)?.ToString();
        }
    }
}