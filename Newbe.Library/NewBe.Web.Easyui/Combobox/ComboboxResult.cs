using System.Collections;
using System.Collections.Generic;

namespace NewBe.Web.Easyui.Combobox
{
    public class ComboboxResult : IEnumerable<ComboboxItem>, IEasyuiResponce
    {
        private readonly IEnumerable<ComboboxItem> _source;

        public ComboboxResult(IEnumerable<ComboboxItem> source)
        {
            _source = source;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ComboboxItem> GetEnumerator()
        {
            return _source.GetEnumerator();
        }
    }
}