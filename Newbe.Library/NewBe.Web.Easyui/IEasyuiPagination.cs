using Newtonsoft.Json;

namespace NewBe.Web.Easyui
{
    public interface IEasyuiPagination : IEasyuiRequestParameter
    {
        [JsonProperty("rows")]
        int Rows { get; set; }

        [JsonProperty("page")]
        int Page { get; set; }
    }
}