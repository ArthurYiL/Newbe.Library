#if NET452
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Newbe.Web.Mvc.Easyui.HtmlHelpers
{
    public interface IEasyuiGridHelper<T> : IDisposable
    {
        HtmlHelper HtmlHelper { get; }
    }

    public interface IEasyuiDatagridToolbar : IDisposable
    {
    }

    internal class EasyuiGridHelper<T> : IEasyuiGridHelper<T>
    {
        public HtmlHelper HtmlHelper { get; set; }

        public void Dispose()
        {
            EasyuiGridExtensions.EndEasyuiGrid(HtmlHelper);
        }
    }

    public static class EasyuiGridExtensions
    {
        public static IEasyuiGridHelper<T> EasyuiGird<T>(this HtmlHelper helper, EasyuiGridOptions options)
            where T : class
        {
            var grid = new EasyuiGridHelper<T>
            {
                HtmlHelper = helper
            };
            BeginEasyuiGrid(helper, options);
            return grid;
        }

        internal static void BeginEasyuiGrid(this HtmlHelper htmlHelper, EasyuiGridOptions options)
        {
            var tableTagBuilder = new TagBuilder("table");
            tableTagBuilder.AddCssClass("easyui-datagrid");
            tableTagBuilder.GenerateId(options.Id);
            tableTagBuilder.MergeAttribute("data-options", GetDataOptionsString(options));
            htmlHelper.ViewContext.Writer.Write(tableTagBuilder.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write("<thead><tr>");
        }

        internal static void EndEasyuiGrid(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write("</tr></thead></table>");
        }

        public static MvcHtmlString Column<T, TKey>(this IEasyuiGridHelper<T> grid,
            Expression<Func<T, TKey>> columnSelector)
        {
            return EasyuiGridExtensions.Column(grid, columnSelector, new EasyuiColumnOptions());
        }

        public static MvcHtmlString Column<T, TKey>(this IEasyuiGridHelper<T> grid,
            Expression<Func<T, TKey>> columnSelector,
            EasyuiColumnOptions options)
        {
            var tagb = new TagBuilder("th");
            var propertyName = ((MemberExpression) columnSelector.Body).Member.Name;
            if (string.IsNullOrEmpty(options.Field))
            {
                options.Field = propertyName;
            }
            tagb.MergeAttribute("data-options", GetDataOptionsString(options));
            tagb.SetInnerText(propertyName);
            return new MvcHtmlString(tagb.ToString());
        }

        private static string GetDataOptionsString<T>(T options)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(options, jsonSerializerSettings);
            var dic = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            var opt = new EasyuiOptionsBuilder(dic).ToString();
            return opt;
        }
    }

    public class EasyuiGridOptions
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("columns")]
        public string Columns { get; set; }

        [JsonProperty("frozenColumns")]
        public string FrozenColumns { get; set; }

        [JsonProperty("fitColumns")]
        public bool? FitColumns { get; set; }

        [JsonProperty("resizeHandle")]
        public string ResizeHandle { get; set; }

        [JsonProperty("autoRowHeight")]
        public string AutoRowHeight { get; set; }

        [JsonProperty("toolbar")]
        public string Toolbar { get; set; }

        [JsonProperty("striped")]
        public string Striped { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("nowrap")]
        public string Nowrap { get; set; }

        [JsonProperty("idField")]
        public string IdField { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("loadMsg")]
        public string LoadMsg { get; set; }

        [JsonProperty("emptyMsg")]
        public string EmptyMsg { get; set; }

        [JsonProperty("pagination")]
        public string Pagination { get; set; }

        [JsonProperty("rownumbers")]
        public string Rownumbers { get; set; }

        [JsonProperty("singleSelect")]
        public string SingleSelect { get; set; }

        [JsonProperty("ctrlSelect")]
        public string CtrlSelect { get; set; }

        [JsonProperty("checkOnSelect")]
        public string CheckOnSelect { get; set; }

        [JsonProperty("selectOnCheck")]
        public string SelectOnCheck { get; set; }

        [JsonProperty("pagePosition")]
        public string PagePosition { get; set; }

        [JsonProperty("pageNumber")]
        public string PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public string PageSize { get; set; }

        [JsonProperty("pageList")]
        public string PageList { get; set; }

        [JsonProperty("queryParams")]
        public string QueryParams { get; set; }

        [JsonProperty("sortName")]
        public string SortName { get; set; }

        [JsonProperty("sortOrder")]
        public string SortOrder { get; set; }

        [JsonProperty("multiSort")]
        public string MultiSort { get; set; }

        [JsonProperty("remoteSort")]
        public string RemoteSort { get; set; }

        [JsonProperty("showHeader")]
        public string ShowHeader { get; set; }

        [JsonProperty("showFooter")]
        public string ShowFooter { get; set; }

        [JsonProperty("scrollbarSize")]
        public string ScrollbarSize { get; set; }

        [JsonProperty("rownumberWidth")]
        public string RownumberWidth { get; set; }

        [JsonProperty("editorHeight")]
        public string EditorHeight { get; set; }

        [JsonProperty("rowStyler")]
        public string RowStyler { get; set; }

        [JsonProperty("loader")]
        public string Loader { get; set; }

        [JsonProperty("loadFilter")]
        public string LoadFilter { get; set; }

        [JsonProperty("editors")]
        public string Editors { get; set; }

        [JsonProperty("view")]
        public string View { get; set; }
    }

    public class EasyuiColumnOptions
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; } = 100;

        [JsonProperty("rowspan")]
        public string Rowspan { get; set; }

        [JsonProperty("colspan")]
        public string Colspan { get; set; }

        [JsonProperty("align")]
        public string Align { get; set; }

        [JsonProperty("halign")]
        public string Halign { get; set; }

        [JsonProperty("sortable")]
        public string Sortable { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("resizable")]
        public string Resizable { get; set; }

        [JsonProperty("fixed")]
        public string Fixed { get; set; }

        [JsonProperty("hidden")]
        public string Hidden { get; set; }

        [JsonProperty("checkbox")]
        public string Checkbox { get; set; }

        [JsonProperty("formatter")]
        public string Formatter { get; set; }

        [JsonProperty("styler")]
        public string Styler { get; set; }

        [JsonProperty("sorter")]
        public string Sorter { get; set; }

        [JsonProperty("editor")]
        public string Editor { get; set; }
    }
}

#endif