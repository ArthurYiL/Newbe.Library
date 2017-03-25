using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal class ComboboxAttributeComboboxValueResolver : IComboboxValueResolver
    {
        private PropertyInfo _valuePropertyInfo;
        int IComboboxValueResolver.Order => 1;


        bool IComboboxValueResolver.CanResolve<T>(T item)
        {
            var props = typeof(T).GetRuntimeProperties().ToList();
            var attrDic = props.ToDictionary(x => x, x => x.GetCustomAttributes());
            //获取 text 所对应的字段
            var value = new KeyValuePair<PropertyInfo, IEnumerable<Attribute>>?(
                attrDic.FirstOrDefault(x => x.Value.Any(a => a is EasyuiComboboxValueAttribute)))?.Key;
            if (value == null)
            {
                return false;
            }
            _valuePropertyInfo = value;
            return true;
        }

        string IComboboxValueResolver.ResolveValue<T>(T item)
        {
            return item == null ? string.Empty : _valuePropertyInfo?.GetValue(item)?.ToString();
        }
    }
}