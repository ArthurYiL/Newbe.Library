#if NET452
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui.HtmlHelpers
{
    public static class HtmlFormInputExtensions
    {
        public static MvcHtmlString Hidden(this IHtmlForm form, string name)
        {
            return HtmlFormInputExtensions.Hidden(form, name, (object) null, (IDictionary<string, object>) null);
        }

        public static MvcHtmlString Hidden(this IHtmlForm form, string name, object value)
        {
            return HtmlFormInputExtensions.Hidden(form, name, value, (IDictionary<string, object>) null);
        }

        public static MvcHtmlString Hidden(this IHtmlForm form, string name, object value, object htmlAttributes)
        {
            return HtmlFormInputExtensions.Hidden(form, name, value,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden(this IHtmlForm form, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(form.HtmlHelper, (ModelMetadata) null, value, value == null,
                name,
                htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this IHtmlForm<TModel> form,
            Expression<Func<TModel, TProperty>> expression)
        {
            return HtmlFormInputExtensions.HiddenFor<TModel, TProperty>(form, expression,
                (IDictionary<string, object>) null);
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this IHtmlForm<TModel> form,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return HtmlFormInputExtensions.HiddenFor<TModel, TProperty>(form, expression,
                (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TProperty>(this IHtmlForm<TModel> form,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = form.HtmlHelper;
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression,
                htmlHelper.ViewData);
            return HiddenHelper((HtmlHelper) htmlHelper, metadata, metadata.Model, false,
                ExpressionHelper.GetExpressionText((LambdaExpression) expression), htmlAttributes);
        }

        private static MvcHtmlString HiddenHelper(HtmlHelper htmlHelper, ModelMetadata metadata, object value,
            bool useViewData, string expression, IDictionary<string, object> htmlAttributes)
        {
            byte[] binary = value as byte[];
            if (binary != (byte[]) null)
                value = (object) binary.ToArray();
            byte[] inArray = value as byte[];
            if (inArray != null)
                value = (object) Convert.ToBase64String(inArray);
            return InputHelper(htmlHelper, InputType.Hidden, metadata, expression, value,
                useViewData, false, true, true, (string) null, htmlAttributes);
        }

        private static MvcHtmlString InputHelper(HtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata,
            string name, object value, bool useViewData, bool isChecked, bool setId, bool isExplicitValue, string format,
            IDictionary<string, object> htmlAttributes)
        {
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            TagBuilder tagBuilder1 = new TagBuilder("input");
            tagBuilder1.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder1.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            tagBuilder1.MergeAttribute("name", fullHtmlFieldName, true);
            string b = htmlHelper.FormatValue(value, format);
            bool flag = false;
            switch (inputType)
            {
                case InputType.CheckBox:
                    bool? modelStateValue1 = htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(bool)) as bool?;
                    if (modelStateValue1.HasValue)
                    {
                        isChecked = modelStateValue1.Value;
                        flag = true;
                        goto case InputType.Radio;
                    }
                    else
                        goto case InputType.Radio;
                case InputType.Password:
                    if (value != null)
                    {
                        tagBuilder1.MergeAttribute("value", b, isExplicitValue);
                        break;
                    }
                    break;
                case InputType.Radio:
                    if (!flag)
                    {
                        string modelStateValue2 =
                            htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string)) as string;
                        if (modelStateValue2 != null)
                        {
                            isChecked = string.Equals(modelStateValue2, b, StringComparison.Ordinal);
                            flag = true;
                        }
                    }
                    if (!flag && useViewData)
                        isChecked = htmlHelper.EvalBoolean(fullHtmlFieldName);
                    if (isChecked)
                        tagBuilder1.MergeAttribute("checked", "checked");
                    tagBuilder1.MergeAttribute("value", b, isExplicitValue);
                    break;
                default:
                    string modelStateValue3 = (string) htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string));
                    tagBuilder1.MergeAttribute("value",
                        modelStateValue3 ?? (useViewData ? htmlHelper.EvalString(fullHtmlFieldName, format) : b),
                        isExplicitValue);
                    break;
            }
            if (setId)
                tagBuilder1.GenerateId(fullHtmlFieldName);
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState) &&
                modelState.Errors.Count > 0)
                tagBuilder1.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            tagBuilder1.MergeAttributes<string, object>(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
            if (inputType != InputType.CheckBox)
                return tagBuilder1.ToMvcHtmlString(TagRenderMode.SelfClosing);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(tagBuilder1.ToString(TagRenderMode.SelfClosing));
            TagBuilder tagBuilder2 = new TagBuilder("input");
            tagBuilder2.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Hidden));
            tagBuilder2.MergeAttribute("name", fullHtmlFieldName);
            tagBuilder2.MergeAttribute("value", "false");
            stringBuilder.Append(tagBuilder2.ToString(TagRenderMode.SelfClosing));
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}

#endif