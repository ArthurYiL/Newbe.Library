using Newbe.Web.Mvc.Easyui.Attributes;
using Newtonsoft.Json;

namespace Newbe.Web.Mvc.Easyui.Options
{
    public class EasyuiValidateBoxOptionsValidType
    {
    }

    public enum EasyuiValidateBoxTipPosition
    {
        [JsonProperty("top")] Top,
        [JsonProperty("left")] Left,
        [JsonProperty("right")] Right,
        [JsonProperty("bottom")] Bottom
    }

    public class EasyuiValidateBoxOptions : EasyuiDataOptions
    {
        [JsonProperty("required")]
        public bool? Required { get; set; }

        [EasyuiVersionForm132]
        [JsonProperty("validType")]
        public EasyuiValidateBoxOptionsValidType ValidType { get; set; }

        [EasyuiVersionForm132]
        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("missingMessage")]
        public string MissingMessage { get; set; }

        [JsonProperty("invalidMessage")]
        public string InvalidMessage { get; set; }

        [EasyuiVersionForm132]
        [JsonProperty("tipPosition")]
        public EasyuiValidateBoxTipPosition? TipPosition { get; set; }

        [EasyuiVersionForm133]
        [JsonProperty("deltaX")]
        public int? DeltaX { get; set; }

        [EasyuiVersionForm134]
        [JsonProperty("novalidate")]
        public bool? Novalidate { get; set; }

        [EasyuiVersionForm145]
        [JsonProperty("editable")]
        public bool? Editable { get; set; }

        [EasyuiVersionForm145]
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        [EasyuiVersionForm145]
        [JsonProperty("readonly")]
        public bool? Readonly { get; set; }

        [EasyuiVersionForm145]
        [JsonProperty("validateOnCreate")]
        public bool? ValidateOnCreate { get; set; }

        [EasyuiVersionForm145]
        [JsonProperty("validateOnBlur")]
        public bool? ValidateOnBlur { get; set; }

        #region Events

        [EasyuiVersionForm140]
        [JsonProperty("onBeforeValidate")]
        public EasyuiEvent OnBeforeValidate { get; set; }

        [EasyuiVersionForm140]
        [JsonProperty("onValidate")]
        public EasyuiEvent OnValidate { get; set; }

        #endregion
    }
}