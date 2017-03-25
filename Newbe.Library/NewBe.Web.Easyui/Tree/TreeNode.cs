using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewBe.Web.Easyui.Tree
{
    public class TreeNode<TParent, TSource, TChild> : ITreeNode<TSource>, ITreeNodeWithChildrenNode<TChild>,
        ITreeNodeWithParent<TParent>
    {
        public TreeNode(TSource source, IEnumerable<ITreeNode<TChild>> children, ITreeNode<TParent> parent)
        {
            Source = source;
            Children = children;
            Parent = parent;
        }

        public TreeNode(IEnumerable<ITreeNode<TChild>> children, TSource source)
        {
            Children = children;
            Source = source;
        }

        public TreeNode(TSource source)
        {
            Source = source;
        }

        /// <inheritdoc />
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <inheritdoc />
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <inheritdoc />
        [JsonProperty("iconCls")]
        public string IconCls { get; set; }

        /// <inheritdoc />
        [JsonProperty("checked")]
        public bool? Checked { get; set; }

        /// <inheritdoc />
        [JsonProperty("attributes")]
        public object Attributes { get; set; }

        /// <inheritdoc />
        [JsonProperty("state")]
        public EasyuiTreeNodeState? State { get; set; }

        /// <inheritdoc />
        [JsonProperty("children")]
        public IEnumerable<ITreeNode<TChild>> Children { get; set; }

        [JsonIgnore]
        public string ParentId { get; set; }

        [JsonIgnore]
        public TSource Source { get; }

        [JsonIgnore]
        public ITreeNode<TParent> Parent { get; set; }
    }

    public class TreeNode<T> : TreeNode<T, T, T>
    {
        public TreeNode(T source, IEnumerable<ITreeNode<T>> children, ITreeNode<T> parent)
            : base(source, children, parent)
        {
        }

        public TreeNode(IEnumerable<ITreeNode<T>> children, T source) : base(children, source)
        {
        }

        public TreeNode(T source) : base(source)
        {
        }
    }
}