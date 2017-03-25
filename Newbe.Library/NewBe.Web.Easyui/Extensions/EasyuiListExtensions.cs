using System;
using System.Collections.Generic;
using System.Linq;
using NewBe.Web.Easyui.Combobox;
using NewBe.Web.Easyui.Datagrid;
using NewBe.Web.Easyui.Internals;
using NewBe.Web.Easyui.Tree;

// ReSharper disable once CheckNamespace

namespace NewBe.Web.Easyui
{
    public static class EasyuiListExtensions
    {
        public static IEasyuiList<T> AsEasyuiList<T>(this IEnumerable<T> source)
        {
            var re = new EasyuiList<T>(source);
            return re;
        }

        /// <summary>
        /// formate source to easyui responce
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="easyuiAccept"></param>
        /// <returns></returns>
        public static IEasyuiResponce FormateByAccept<T>(this IEasyuiList<T> source,
            IEasyuiAccept easyuiAccept)
        {
            return FormateByAccept(source, easyuiAccept.Accept);
        }

        /// <summary>
        /// formate source to easyui responce
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="accept"></param>
        /// <returns></returns>
        public static IEasyuiResponce FormateByAccept<T>(this IEasyuiList<T> source,
            EasyuiAcceptType accept)
        {
            switch (accept)
            {
                case EasyuiAcceptType.NotSpecificated:
                    return source;
                case EasyuiAcceptType.Datagrid:
                    return ToDatagridResult(source);
                case EasyuiAcceptType.Combobox:
                    return ToComboboxResult(source);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static ComboboxResult ToComboboxResult<T>(this IEasyuiList<T> source)
        {
            var comboboxResultFactory =
                Container.Global.Resolve<IComboboxResultFactory>();
            var re = comboboxResultFactory.Build(source);
            return re;
        }

        public static ComboboxResult ToComboboxResult<T>(this IEasyuiList<T> source,
            ComboboxResultBuildOptions<T> buildOptions)
        {
            var re = new ComboboxResult(source.AsEnumerable().Select(x => new ComboboxItem
            {
                Text = buildOptions.TextFunc(x),
                Value = buildOptions.ValueFunc(x),
            }));
            return re;
        }

        public static DatagridResult<T> ToDatagridResult<T>(this IEasyuiList<T> source)
        {
            return new DatagridResult<T>(source);
        }

        public static DatagridResult<T> ToDatagridResult<T>(this IEasyuiList<T> source, int total)
        {
            return new DatagridResult<T>(source)
            {
                Total = total
            };
        }


        public static TreeResult<T> ToTreeResult<T>(this IEasyuiList<T> source, EasyuiTreeBuildOptions<T> buildOptions)
        {
            var treeResultFactory =
                Container.Global.Resolve<ITreeResultFactory>();
            var re = treeResultFactory.Build(source, buildOptions);
            return re;
        }
    }
}