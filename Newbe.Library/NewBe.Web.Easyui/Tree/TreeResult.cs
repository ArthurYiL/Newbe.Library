using System.Collections;
using System.Collections.Generic;

namespace NewBe.Web.Easyui.Tree
{
    public class TreeResult<T> : IEnumerable<TreeNode<T>>, IEasyuiResponce
    {
        private readonly IEnumerable<TreeNode<T>> _source;

        public TreeResult(IEnumerable<TreeNode<T>> source)
        {
            _source = source;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return _source.GetEnumerator();
        }
    }
}