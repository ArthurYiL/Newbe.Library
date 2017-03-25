using System.Collections.Generic;

namespace NewBe.Web.Easyui.Tree
{
    public interface ITreeNodeWithChildrenNode<out TChildrenSource> : ITreeNode
    {
        IEnumerable<ITreeNode<TChildrenSource>> Children { get; }
    }
}