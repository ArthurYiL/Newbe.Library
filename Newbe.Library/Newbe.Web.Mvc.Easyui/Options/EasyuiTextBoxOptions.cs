using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Web.Mvc.Easyui.Attributes;
using Newtonsoft.Json;

namespace Newbe.Web.Mvc.Easyui.Options
{
    public enum EasyuiTextBoxOptionsType
    {
        [JsonProperty("text")] Text,
        [JsonProperty("password")] Password,
    }

    public enum EasyuiTextBoxOptionsLabelPosition
    {
        [JsonProperty("before")] Before,
        [JsonProperty("after")] After,
        [JsonProperty("top")] Top,
    }

    public enum EasyuiTextBoxOptionsLabelAlign
    {
        [JsonProperty("left")] Left,
        [JsonProperty("right")] Right,
    }

    public enum EasyuiTextBoxOptionsIconAlign
    {
        [JsonProperty("left")] Left,
        [JsonProperty("right")] Right,
    }

    public enum EasyuiTextBoxOptionsButtonAlign
    {
        [JsonProperty("left")] Left,
        [JsonProperty("right")] Right,
    }

    public class EasyuiTextBoxOptionsIcon
    {
        [JsonProperty("iconCls")]
        public string IconCls { get; set; }

        [JsonProperty("disabled")]
        public string Disabled { get; set; }

        [JsonProperty("handler")]
        public JsFunction Handler { get; set; }
    }

    public class EasyuiTextBoxOptions : EasyuiDataOptions
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [EasyuiVersionForm151]
        [JsonProperty("cls")]
        public string Cls { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public EasyuiTextBoxOptionsType? Type { get; set; }

        [EasyuiVersionForm150]
        [JsonProperty("label")]
        public string Label { get; set; }

        [EasyuiVersionForm150]
        [JsonProperty("labelWidth")]
        public string LabelWidth { get; set; }

        [EasyuiVersionForm150]
        [JsonProperty("labelPosition")]
        public EasyuiTextBoxOptionsLabelPosition? LabelPosition { get; set; }

        [EasyuiVersionForm150]
        [JsonProperty("labelAlign")]
        public EasyuiTextBoxOptionsLabelAlign? LabelAlign { get; set; }

        [JsonProperty("multiline")]
        public bool? Multiline { get; set; }

        [JsonProperty("editable")]
        public bool? Editable { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        [JsonProperty("readonly")]
        public bool? Readonly { get; set; }

        [JsonProperty("icons")]
        public IEnumerable<EasyuiTextBoxOptionsIcon> Icons { get; set; }

        [JsonProperty("iconCls")]
        public string IconCls { get; set; }

        [JsonProperty("iconAlign")]
        public EasyuiTextBoxOptionsIconAlign? IconAlign { get; set; }

        [JsonProperty("iconWidth")]
        public int IconWidth { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [JsonProperty("buttonIcon")]
        public string ButtonIcon { get; set; }

        [JsonProperty("buttonAlign")]
        public EasyuiTextBoxOptionsButtonAlign? ButtonAlign { get; set; }

        #region Events

        [JsonProperty("onChange")]
        public EasyuiEvent OnChange { get; set; }

        [JsonProperty("onResize")]
        public EasyuiEvent OnResize { get; set; }

        [JsonProperty("onClickButton")]
        public EasyuiEvent OnClickButton { get; set; }

        [JsonProperty("onClickIcon")]
        public EasyuiEvent OnClickIcon { get; set; }

        #endregion
    }
}