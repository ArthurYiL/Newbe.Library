using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NewBe.Web.Easyui.Tree
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EasyuiTreeNodeState
    {
        [JsonProperty("open")] Open,
        [JsonProperty("closed")] Closed
    }
}