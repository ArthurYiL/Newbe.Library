using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace NewBe.Web.Easyui.Tree
{
    public class TreeResultFactory : ITreeResultFactory
    {
        private static readonly ConcurrentDictionary<Type, TreePropertyResolver> TreeBuilderCache =
            new ConcurrentDictionary<Type, TreePropertyResolver>();

        class TreePropertyResolver
        {
            public PropertyInfo TextResolver { get; set; }
            public PropertyInfo IdResolver { get; set; }
        }

        TreeResult<T> ITreeResultFactory.Build<T>(IEasyuiList<T> items, EasyuiTreeBuildOptions<T> buildOptions)
        {
            var type = typeof(T);
            var builder = TreeBuilderCache.GetOrAdd(type, type1 =>
            {
                var r = new TreePropertyResolver();
                var properInfos = type.GetRuntimeProperties().ToArray();
                r.IdResolver =
                    properInfos.FirstOrDefault(
                        x => x.CustomAttributes.Any(a => a.AttributeType == typeof(EasyuiTreeIdAttribute)));
                r.TextResolver =
                    properInfos.FirstOrDefault(
                        x => x.CustomAttributes.Any(a => a.AttributeType == typeof(EasyuiTreeTextAttribute)));
                return r;
            });
            var re = new TreeResult<T>(items.AsEnumerable().Select(x =>
            {
                var treeNode = new TreeNode<T>(x, null, null)
                {
                    Attributes = buildOptions.AttributesFunc?.Invoke(x),
                };
                if (buildOptions.IdFunc == null && builder.IdResolver == null)
                {
                    throw new ArgumentNullException(nameof(buildOptions.IdFunc));
                }
                treeNode.Id = buildOptions.IdFunc == null
                    ? builder.IdResolver.GetValue(x)?.ToString()
                    : buildOptions.IdFunc(x);
                if (buildOptions.TextFunc == null && builder.TextResolver == null)
                {
                    throw new ArgumentNullException(nameof(buildOptions.TextFunc));
                }
                treeNode.Text = buildOptions.TextFunc == null
                    ? builder.TextResolver.GetValue(x)?.ToString()
                    : buildOptions.TextFunc(x);
                return treeNode;
            }));
            return re;
        }
    }
}