using Newtonsoft.Json;

namespace NewBe.Web.Easyui
{
    public interface IEasyuiSorter : IEasyuiRequestParameter
    {
        [JsonProperty("sort")]
        string SortBy { get; set; }

        [JsonProperty("order")]
        SortOrder Order { get; set; }
    }
}