namespace NewBe.Web.Easyui.Tree
{
    public interface ITreeNodeWithParent<out TParentSource> : ITreeNode
    {
        ITreeNode<TParentSource> Parent { get; }
    }
}