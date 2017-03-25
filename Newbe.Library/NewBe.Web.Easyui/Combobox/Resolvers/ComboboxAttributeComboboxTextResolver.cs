using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal class ComboboxAttributeComboboxTextResolver : IComboboxTextResolver
    {
        private PropertyInfo _textPropertyInfo;
        int IComboboxTextResolver.Order => 1;


        bool IComboboxTextResolver.CanResolve<T>(T item)
        {
            var props = typeof(T).GetRuntimeProperties().ToList();
            var attrDic = props.ToDictionary(x => x, x => x.GetCustomAttributes());
            //获取 text 所对应的字段
            var text = new KeyValuePair<PropertyInfo, IEnumerable<Attribute>>?(
                attrDic.FirstOrDefault(x => x.Value.Any(a => a is EasyuiComboboxTextAttribute)))?.Key;
            if (text == null)
            {
                return false;
            }
            _textPropertyInfo = text;
            return true;
        }

        string IComboboxTextResolver.ResolveText<T>(T item)
        {
            return item == null ? string.Empty : _textPropertyInfo?.GetValue(item)?.ToString();
        }
    }
}