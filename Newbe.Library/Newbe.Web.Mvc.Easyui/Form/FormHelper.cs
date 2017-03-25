
#if NET452
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui.Form
{
    internal static class TlwHtmlAttributesBuilder
    {
        public const string AttribuesPrefix = "newbe-";

        public static string GetAttributeName(string name) => $"{AttribuesPrefix}{name}";
    }

    public interface IHtmlForm : IDisposable
    {
        HtmlHelper HtmlHelper { get; }
    }

    public interface IHtmlForm<T> : IDisposable
    {
        HtmlHelper<T> HtmlHelper { get; }
        T Model { get; }
    }

    internal class HtmlForm<T> : IHtmlForm<T>
    {
        public HtmlForm(HtmlHelper<T> htmlHelper, T model)
        {
            HtmlHelper = htmlHelper;
            Model = model;
        }

        public HtmlHelper<T> HtmlHelper { get; set; }
        public T Model { get; }

        public void Dispose()
        {
            this.EndForm();
        }
    }

    internal class HtmlForm : IHtmlForm
    {
        public HtmlForm(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public HtmlHelper HtmlHelper { get; set; }

        public void Dispose()
        {
            this.EndForm();
        }
    }

    public class FormOptions
    {
        public FormMethod HttpMethod { get; set; } = FormMethod.Post;
        public string Url { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }
    }

    public class FormOptions<T> : FormOptions
    {
        public T Model { get; set; }
    }

    public static class FormHelper
    {
        public static IHtmlForm HtmlForm(this HtmlHelper helper, FormOptions options)
        {
            var tlwForm = new HtmlForm(helper);
            BeginFormTag(tlwForm, options);
            return tlwForm;
        }

        public static IHtmlForm<T> HtmlForm<T>(this HtmlHelper helper, FormOptions<T> options) where T : new()
        {
            var htmlHelper = new HtmlHelper<T>(helper.ViewContext, helper.ViewDataContainer);
            if (options.Model == null)
            {
                options.Model = new T();
            }
            var tlwForm = new HtmlForm<T>(htmlHelper, options.Model);
            BeginFormTag(tlwForm, options);
            return tlwForm;
        }

        private static void BeginFormTag(IHtmlForm form, FormOptions options)
        {
            BeginFormTag(form.HtmlHelper, options);
        }

        private static void BeginFormTag<T>(IHtmlForm<T> form, FormOptions options)
        {
            BeginFormTag(form.HtmlHelper, options);
        }

        internal static void EndForm(this IHtmlForm form)
        {
            EndForm(form.HtmlHelper);
        }

        internal static void EndForm<T>(this IHtmlForm<T> form)
        {
            EndForm(form.HtmlHelper);
        }

        internal static void EndForm(HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write("</form>");
            htmlHelper.ViewContext.OutputClientValidation();
        }


        private static void BeginFormTag(HtmlHelper htmlHelper, FormOptions options)
        {
            var tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttributes(options.HtmlAttributes);
            tagBuilder.MergeAttribute("action", options.Url);
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(options.HttpMethod), true);
            tagBuilder.MergeAttribute(TlwHtmlAttributesBuilder.GetAttributeName("ajax-form"), null);
            tagBuilder.MergeAttribute(TlwHtmlAttributesBuilder.GetAttributeName("ajax-method"),
                HtmlHelper.GetFormMethodString(options.HttpMethod), true);
            tagBuilder.MergeAttribute(TlwHtmlAttributesBuilder.GetAttributeName("ajax-action"), options.Url);
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
        }
    }
}

#endif