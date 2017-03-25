#if NET452
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui.HtmlHelpers
{
    public static class HtmlFormEasyuiInputExtensions
    {
        #region EasyuiTextBox

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value,
            string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.TextBox);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlForm.EasyuiTextBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiTextBoxFor<TModel>(this IHtmlForm<TModel> htmlForm, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            return EasyuiInputExtension.EasyuiInputHelper(htmlForm.HtmlHelper, metadata, expression, model, false, true,
                true,
                format, htmlAttributes, EasyuiFormControlType.TextBox);
        }

        #endregion

        #region EasyuiValidateBox

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value,
            string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.ValidateBox);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiValidateBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiValidateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlForm.EasyuiValidateBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiValidateBoxFor<TModel>(this IHtmlForm<TModel> htmlForm,
            ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.ValidateBox);
        }

        #endregion

        #region EasyuiDateBox

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value,
            string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.DateBox);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBoxFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBoxFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBoxFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBoxFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateBoxFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateBoxFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlForm.EasyuiDateBoxFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiDateBoxFor<TModel>(this IHtmlForm<TModel> htmlForm, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.DateBox);
        }

        #endregion

        #region EasyuiDateTimeBox

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, (object) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value,
            string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiDateTimeBox(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiDateTimeBox(this IHtmlForm htmlForm, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.DatetimeBox);
        }

        #endregion

        #region EasyuiTextArea

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, (object) null);
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, value, (string) null);
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value,
            string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, value, format, (object) null);
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value,
            string format,
            object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, value, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextArea(name, value, null, htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextArea(this IHtmlForm htmlForm, string name, object value,
            string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, (ModelMetadata) null, name, value, value == null,
                true,
                true, format, htmlAttributes, EasyuiFormControlType.TextArea);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextAreaFor(expression, (string) null);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextAreaFor(expression, format,
                null);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextAreaFor<TModel, TProperty>(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextAreaFor(expression, format,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return htmlHelper.EasyuiTextAreaFor(expression, (string) null,
                htmlAttributes);
        }

        public static MvcHtmlString EasyuiTextAreaFor<TModel, TProperty>(this IHtmlForm<TModel> htmlForm,
            Expression<Func<TModel, TProperty>> expression, string format,
            IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlForm.EasyuiTextAreaFor(metadata, metadata.Model,
                ExpressionHelper.GetExpressionText(expression), format, htmlAttributes);
        }

        private static MvcHtmlString EasyuiTextAreaFor<TModel>(this IHtmlForm<TModel> htmlForm, ModelMetadata metadata,
            object model,
            string expression, string format, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = htmlForm.HtmlHelper;
            return EasyuiInputExtension.EasyuiInputHelper(htmlHelper, metadata, expression, model, false, true, true,
                format, htmlAttributes, EasyuiFormControlType.TextArea);
        }

        #endregion
    }
}

#endif