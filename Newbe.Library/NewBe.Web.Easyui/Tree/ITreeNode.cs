namespace NewBe.Web.Easyui.Tree
{
    public interface ITreeNode<out T> : ITreeNode
    {
        T Source { get; }
    }

    public interface ITreeNode
    {
        /// <summary>
        /// An identity value bind to the node.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Text to be showed.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// The css class to display icon.
        /// </summary>
        string IconCls { get; set; }

        /// <summary>
        /// Whether the node is checked.
        /// </summary>
        bool? Checked { get; set; }

        /// <summary>
        ///  Custom attributes bind to the node.
        /// </summary>
        object Attributes { get; set; }

        /// <summary>
        /// The node state, 'open' or 'closed'.
        /// </summary>
        EasyuiTreeNodeState? State { get; set; }

        /// <summary>
        /// ParentNodeId
        /// </summary>
        string ParentId { get; set; }
    }
}