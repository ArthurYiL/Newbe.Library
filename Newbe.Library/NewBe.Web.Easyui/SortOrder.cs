using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NewBe.Web.Easyui
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        [JsonProperty("asc")] Asc,
        [JsonProperty("desc")] Desc
    }
}