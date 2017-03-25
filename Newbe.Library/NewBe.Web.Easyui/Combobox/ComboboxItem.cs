using Newtonsoft.Json;

namespace NewBe.Web.Easyui.Combobox
{
    public class ComboboxItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}