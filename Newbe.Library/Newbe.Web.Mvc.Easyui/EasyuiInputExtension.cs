
#if NET452
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui
{
    public static class EasyuiInputExtension
    {
        public static MvcHtmlString EasyuiInputHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name,
            object value, bool useViewData, bool setId, bool isExplicitValue, string format,
            IDictionary<string, object> htmlAttributes,
            EasyuiFormControlType easyuiFormType)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullHtmlFieldName))
            {
                throw new ArgumentException("name");
            }
            var tagBuilder = easyuiFormType == EasyuiFormControlType.TextArea
                ? new TagBuilder("textarea")
                : new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.Text));
            tagBuilder.MergeAttribute("name", fullHtmlFieldName, true);
            var b = htmlHelper.FormatValue(value, format);

            var str = (string) htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string));
            var valstr =
                str ?? (useViewData ? htmlHelper.EvalString(fullHtmlFieldName, format) : b);
            tagBuilder.MergeAttribute("value", valstr, isExplicitValue);
            if (easyuiFormType == EasyuiFormControlType.TextArea)
            {
                tagBuilder.SetInnerText(valstr);
            }
            if (setId)
                tagBuilder.GenerateId(fullHtmlFieldName);
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState) &&
                modelState.Errors.Count > 0)
            {
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
            if (easyuiFormType == EasyuiFormControlType.TextArea)
            {
                tagBuilder.AddCssClass("easyui-" + EasyuiFormControlType.ValidateBox.ToString().ToLower());
            }
            else
            {
                tagBuilder.AddCssClass("easyui-" + easyuiFormType.ToString().ToLower());
            }
            EasyuiValidationExtension.MergeEasyuiValidation(htmlHelper, metadata, name, tagBuilder);
            if (easyuiFormType == EasyuiFormControlType.TextArea)
            {
                return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
            }
            else
            {
                return tagBuilder.ToMvcHtmlString(TagRenderMode.SelfClosing);
            }
        }

        #region EasyuiTextBox

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.EasyuiTextBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.EasyuiTextBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value,
            string format)
        {
            return htmlHelper.EasyuiTextBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiTextBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiTextBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiTextBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.TextBox);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.EasyuiTextBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.EasyuiTextBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.EasyuiTextBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.EasyuiTextBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiTextBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlHelper.EasyuiTextBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiTextBoxFor(this HtmlHelper htmlHelper, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.TextBox);
        }

        #endregion

        #region EasyuiValidateBox

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.EasyuiValidateBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.EasyuiValidateBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value,
            string format)
        {
            return htmlHelper.EasyuiValidateBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.ValidateBox);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.EasyuiValidateBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.EasyuiValidateBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiValidateBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlHelper.EasyuiValidateBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiValidateBoxFor(this HtmlHelper htmlHelper, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.ValidateBox);
        }

        #endregion

        #region EasyuiDateBox

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.EasyuiDateBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.EasyuiDateBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value,
            string format)
        {
            return htmlHelper.EasyuiDateBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiDateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiDateBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiDateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.DateBox);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.EasyuiDateBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.EasyuiDateBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.EasyuiDateBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.EasyuiDateBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiDateBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlHelper.EasyuiDateBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiDateBoxFor(this HtmlHelper htmlHelper, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.DateBox);
        }

        #endregion

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.EasyuiDateTimeBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.EasyuiDateTimeBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value,
            string format)
        {
            return htmlHelper.EasyuiDateTimeBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiDateTimeBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiDateTimeBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiDateTimeBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this HtmlHelper htmlHelper, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.DatetimeBox);
        }

        #region EasyuiTextArea

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.EasyuiTextArea(name, (object) null);
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.EasyuiTextArea(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value,
            string format)
        {
            return htmlHelper.EasyuiTextArea(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiTextArea(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value,
            string format,
            object htmlAttributes)
        {
            return htmlHelper.EasyuiTextArea(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiTextArea(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextArea(this HtmlHelper htmlHelper, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.TextArea);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.EasyuiTextAreaFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            return htmlHelper.EasyuiTextAreaFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.EasyuiTextAreaFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            return htmlHelper.EasyuiTextAreaFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.EasyuiTextAreaFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlHelper.EasyuiTextAreaFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiTextAreaFor(this HtmlHelper htmlHelper, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.TextArea);
        }

        #endregion
    }
}

#endif