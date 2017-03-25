using Newtonsoft.Json;

namespace NewBe.Web.Easyui
{
    public interface IEasyuiAccept : IEasyuiRequestParameter
    {
        [JsonProperty("Accept")]
        EasyuiAcceptType Accept { get; set; }
    }
}