
#if NET452
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Newbe.Web.Mvc.Easyui.Form
{
    public static class HtmlFormEasyuiSelectExtensions
    {
        private static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression, string optionLabel, IDictionary<string, object> htmlAttributes,
            EasyuiFormControlType easyuiFormType)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TEnum>(expression, htmlHelper.ViewData);
            if (metadata == null)
                throw new ArgumentNullException("expression metadata");
            if (metadata.ModelType == (Type) null)
                throw new ArgumentNullException("expression ModelType");
            if (!EnumHelper.IsValidForEnumHelper(metadata.ModelType))
                throw new ArgumentNullException("expression IsValidForEnumHelper");
            var expressionText = ExpressionHelper.GetExpressionText((LambdaExpression) expression);
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);
            var @enum = (Enum) null;
            if (!string.IsNullOrEmpty(fullHtmlFieldName))
                @enum = htmlHelper.GetModelStateValue(fullHtmlFieldName, metadata.ModelType) as Enum;
            if (@enum == null && !string.IsNullOrEmpty(expressionText))
                @enum = htmlHelper.ViewData.Eval(expressionText) as Enum;
            if (@enum == null)
                @enum = metadata.Model as Enum;
            var selectList = EnumHelper.GetSelectList(metadata.ModelType, @enum);
            if (!string.IsNullOrEmpty(optionLabel) && selectList.Count != 0 && string.IsNullOrEmpty(selectList[0].Text))
            {
                selectList[0].Text = optionLabel;
                optionLabel = (string) null;
            }
            return DropDownListHelper((HtmlHelper) htmlHelper, metadata, expressionText,
                (IEnumerable<SelectListItem>) selectList, optionLabel, htmlAttributes, easyuiFormType);
        }

        private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string expression,
            IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes,
            EasyuiFormControlType easyuiFormType)
        {
            return SelectInternal(htmlHelper, metadata, optionLabel, expression, selectList, false, htmlAttributes,
                easyuiFormType);
        }

        private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name)
        {
            var obj = (object) null;
            if (htmlHelper.ViewData != null)
                obj = htmlHelper.ViewData.Eval(name);
            if (obj == null)
                throw new InvalidOperationException("缺少选择项");
            var enumerable = obj as IEnumerable<SelectListItem>;
            if (enumerable == null)
                throw new InvalidOperationException("错误的选择项类型");
            return enumerable;
        }

        internal static string ListItemToOption(SelectListItem item)
        {
            var tagBuilder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
                tagBuilder.Attributes["value"] = item.Value;
            if (item.Selected)
                tagBuilder.Attributes["selected"] = "selected";
            if (item.Disabled)
                tagBuilder.Attributes["disabled"] = "disabled";
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        private static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList,
            object defaultValue, bool allowMultiple)
        {
            IEnumerable source;
            if (allowMultiple)
            {
                source = defaultValue as IEnumerable;
                if (source == null || source is string)
                    throw new InvalidOperationException("选择表达式为返回IEnumerable类型");
            }
            else
                source = (IEnumerable) new object[1]
                {
                    defaultValue
                };
            var hashSet =
                new HashSet<string>(
                    collection: Enumerable.Concat(first: Enumerable.Select(Enumerable.Cast<object>(source), selector:
                            value => Convert.ToString(value, (IFormatProvider) CultureInfo.CurrentCulture)),
                        second: Enumerable.Select(
                            Enumerable.Cast<Enum>(Enumerable.OfType<Enum>(source) as IEnumerable),
                            selector: (Func<Enum, string>) (value => value.ToString("d")))),
                    comparer: (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
            var list = new List<SelectListItem>();
            foreach (var selectListItem in selectList)
            {
                selectListItem.Selected = selectListItem.Value != null
                    ? hashSet.Contains(selectListItem.Value)
                    : hashSet.Contains(selectListItem.Text);
                list.Add(selectListItem);
            }
            return list as IEnumerable<SelectListItem>;
        }

        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata,
            string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple,
            IDictionary<string, object> htmlAttributes, EasyuiFormControlType easyuiFormType)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullHtmlFieldName))
                throw new ArgumentNullException("name");
            var flag = false;
            if (selectList == null)
            {
                selectList = GetSelectData(htmlHelper, name);
                flag = true;
            }
            var defaultValue = allowMultiple
                ? htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string[]))
                : htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string));
            if (defaultValue == null && !string.IsNullOrEmpty(name))
            {
                if (!flag)
                    defaultValue = htmlHelper.ViewData.Eval(name);
                else if (metadata != null)
                    defaultValue = metadata.Model;
            }
            if (defaultValue != null)
                selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple);
            StringBuilder stringBuilder = BuildItems(optionLabel, selectList);
            var tagBuilder = new TagBuilder("select")
            {
                InnerHtml = stringBuilder.ToString()
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullHtmlFieldName, true);
            tagBuilder.GenerateId(fullHtmlFieldName);
            if (allowMultiple)
            {
                tagBuilder.MergeAttribute("multiple", "multiple");
            }
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState) &&
                modelState.Errors.Count > 0)
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            tagBuilder.AddCssClass("easyui-" + easyuiFormType.ToString().ToLower());
            EasyuiValidationExtension.MergeEasyuiValidation(htmlHelper, metadata, name, tagBuilder);
            return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private static StringBuilder BuildItems(string optionLabel, IEnumerable<SelectListItem> selectList)
        {
            var stringBuilder = new StringBuilder();
            if (optionLabel != null)
                stringBuilder.AppendLine(ListItemToOption(new SelectListItem()
                {
                    Text = optionLabel,
                    Value = string.Empty,
                    Selected = false
                }));
            foreach (
                var grouping in
                Enumerable.GroupBy<SelectListItem, int>(selectList, (Func<SelectListItem, int>) (i =>
                {
                    if (i.Group != null)
                        return i.Group.GetHashCode();
                    return i.GetHashCode();
                })))
            {
                var group = Enumerable.First<SelectListItem>((IEnumerable<SelectListItem>) grouping).Group;
                var tagBuilder = (TagBuilder) null;
                if (group != null)
                {
                    tagBuilder = new TagBuilder("optgroup");
                    if (group.Name != null)
                        tagBuilder.MergeAttribute("label", group.Name);
                    if (group.Disabled)
                        tagBuilder.MergeAttribute("disabled", "disabled");
                    stringBuilder.AppendLine(tagBuilder.ToString(TagRenderMode.StartTag));
                }
                foreach (var selectListItem in (IEnumerable<SelectListItem>) grouping)
                    stringBuilder.AppendLine(ListItemToOption(selectListItem));
                if (group != null)
                    stringBuilder.AppendLine(tagBuilder.ToString(TagRenderMode.EndTag));
            }
            return stringBuilder;
        }

#region EasyuiCombo

        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name)
        {
            return EasyuiCombo(htmlForm, name, (IEnumerable<SelectListItem>) null, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name, string optionLabel)
        {
            return EasyuiCombo(htmlForm, name, (IEnumerable<SelectListItem>) null, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList)
        {
            return EasyuiCombo(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return EasyuiCombo(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiCombo(htmlForm, name, selectList, (string) null, htmlAttributes);
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiCombo(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return EasyuiCombo(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiCombo(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return DropDownListHelper(htmlHelper, (ModelMetadata) null, name, selectList, optionLabel, htmlAttributes,
                EasyuiFormControlType.Combo);
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return EasyuiComboFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            object htmlAttributes)
        {
            return EasyuiComboFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiComboFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiComboFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            object htmlAttributes)
        {
            return EasyuiComboFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression,
                htmlHelper.ViewData);
            return DropDownListHelper((HtmlHelper) htmlHelper, metadata,
                ExpressionHelper.GetExpressionText((LambdaExpression) expression), selectList, optionLabel,
                htmlAttributes, EasyuiFormControlType.Combo);
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression)
        {
            return EasyuiEnumComboFor<TModel, TEnum>(htmlForm, expression, (string) null);
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            return EasyuiEnumComboFor(htmlForm, expression, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiEnumComboFor(htmlForm, expression, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel)
        {
            return EasyuiEnumComboFor(htmlForm, expression, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel, object htmlAttributes)
        {
            return EasyuiEnumComboFor<TModel, TEnum>(htmlForm, expression, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiEnumComboFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EnumDropDownListFor(htmlHelper, expression, optionLabel, htmlAttributes, EasyuiFormControlType.Combo);
        }

#endregion

#region EasyuiComboBox

        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name)
        {
            return EasyuiComboBox(htmlForm, name, (IEnumerable<SelectListItem>) null, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name, string optionLabel)
        {
            return EasyuiComboBox(htmlForm, name, (IEnumerable<SelectListItem>) null, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList)
        {
            return EasyuiComboBox(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return EasyuiComboBox(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiComboBox(htmlForm, name, selectList, (string) null, htmlAttributes);
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiComboBox(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return EasyuiComboBox(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboBox(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return DropDownListHelper(htmlHelper, (ModelMetadata) null, name, selectList, optionLabel, htmlAttributes,
                EasyuiFormControlType.ComboBox);
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return EasyuiComboBoxFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            object htmlAttributes)
        {
            return EasyuiComboBoxFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiComboBoxFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiComboBoxFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            object htmlAttributes)
        {
            return EasyuiComboBoxFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression,
                htmlHelper.ViewData);
            return DropDownListHelper((HtmlHelper) htmlHelper, metadata,
                ExpressionHelper.GetExpressionText((LambdaExpression) expression), selectList, optionLabel,
                htmlAttributes, EasyuiFormControlType.ComboBox);
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression)
        {
            return EasyuiEnumComboBoxFor<TModel, TEnum>(htmlForm, expression, (string) null);
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            return EasyuiEnumComboBoxFor(htmlForm, expression, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiEnumComboBoxFor(htmlForm, expression, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel)
        {
            return EasyuiEnumComboBoxFor(htmlForm, expression, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel, object htmlAttributes)
        {
            return EasyuiEnumComboBoxFor<TModel, TEnum>(htmlForm, expression, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiEnumComboBoxFor<TModel, TEnum>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TEnum>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EnumDropDownListFor(htmlHelper, expression, optionLabel, htmlAttributes, EasyuiFormControlType.ComboBox);
        }

#endregion

#region EasyuiComboBox

        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name)
        {
            return EasyuiComboTree(htmlForm, name, (IEnumerable<SelectListItem>) null, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name, string optionLabel)
        {
            return EasyuiComboTree(htmlForm, name, (IEnumerable<SelectListItem>) null, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList)
        {
            return EasyuiComboTree(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return EasyuiComboTree(htmlForm, name, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiComboTree(htmlForm, name, selectList, (string) null, htmlAttributes);
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiComboTree(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return EasyuiComboTree(htmlForm, name, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboTree(this IHtmlForm htmlForm, string name,
            IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return DropDownListHelper(htmlHelper, (ModelMetadata) null, name, selectList, optionLabel, htmlAttributes,
                EasyuiFormControlType.ComboTree);
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return EasyuiComboTreeFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            object htmlAttributes)
        {
            return EasyuiComboTreeFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiComboTreeFor<TModel, TProperty>(htmlForm, expression, selectList, (string) null,
                htmlAttributes);
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return EasyuiComboTreeFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) null);
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            object htmlAttributes)
        {
            return EasyuiComboTreeFor<TModel, TProperty>(htmlForm, expression, selectList, optionLabel,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel,
            IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression,
                htmlHelper.ViewData);
            return DropDownListHelper((HtmlHelper) htmlHelper, metadata,
                ExpressionHelper.GetExpressionText((LambdaExpression) expression), selectList, optionLabel,
                htmlAttributes, EasyuiFormControlType.ComboTree);
        }

        public static MvcHtmlString EasyuiComboTreeFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression)
        {
            return EasyuiComboTreeFor(htmlForm, expression, new List<SelectListItem>(), null, null);
        }

#endregion
    }
}

#endif