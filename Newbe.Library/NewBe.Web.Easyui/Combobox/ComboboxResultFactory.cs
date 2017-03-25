using System.Collections.Generic;
using System.Linq;
using NewBe.Web.Easyui.Combobox.Exceptions;
using NewBe.Web.Easyui.Combobox.Resolvers;

namespace NewBe.Web.Easyui.Combobox
{
    internal class ComboboxResultFactory : IComboboxResultFactory
    {
        private readonly IEnumerable<IComboboxTextResolver> _comboboxTextResolvers;
        private readonly IEnumerable<IComboboxValueResolver> _comboboxValueResolvers;

        public ComboboxResultFactory(IEnumerable<IComboboxTextResolver> comboboxTextResolvers,
            IEnumerable<IComboboxValueResolver> comboboxValueResolvers)
        {
            _comboboxTextResolvers = comboboxTextResolvers.OrderBy(x => x.Order);
            _comboboxValueResolvers = comboboxValueResolvers.OrderBy(x => x.Order);
        }

        ComboboxResult IComboboxResultFactory.Build<T>(IEasyuiList<T> items)
        {
            var enumerable = items.AsEnumerable() as T[] ?? items?.AsEnumerable()?.ToArray();
            if (!enumerable?.Any() == true)
            {
                return new ComboboxResult(Enumerable.Empty<ComboboxItem>());
            }
            var item = enumerable.First();
            var valueResolver = _comboboxValueResolvers.FirstOrDefault(x => x.CanResolve(item));
            if (valueResolver == null)
            {
                throw new AvaliableResolverNotFoundException();
            }
            var textResolver = _comboboxTextResolvers.FirstOrDefault(x => x.CanResolve(item));
            if (textResolver == null)
            {
                throw new AvaliableResolverNotFoundException();
            }
            var re = enumerable.Select(x => new ComboboxItem
            {
                Text = textResolver.ResolveText(x),
                Value = valueResolver.ResolveValue(x),
            }).ToList();
            return new ComboboxResult(re);
        }
    }
}