using System.Collections.Generic;
using System.Linq;

namespace NewBe.Web.Easyui.Internals
{
    internal class EasyuiList<T> : IEasyuiList<T>
    {
        private readonly IEnumerable<T> _collection;

        public EasyuiList(IEnumerable<T> collection)
        {
            _collection = collection;
        }

        IEnumerable<T> IEasyuiList<T>.AsEnumerable()
        {
            return _collection.AsEnumerable();
        }
    }
}