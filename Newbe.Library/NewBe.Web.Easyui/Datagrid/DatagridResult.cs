using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace NewBe.Web.Easyui.Datagrid
{
    /// <summary>
    ///  easyui-datagrid ·ÖÒ³½á¹û
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatagridResult<T> : IEasyuiResponce
    {
        public DatagridResult()
        {
        }

        public DatagridResult(IEasyuiList<T> rows)
        {
            var enumerable = rows.AsEnumerable() as T[] ?? rows.AsEnumerable().ToArray();
            Rows = enumerable;
            Total = enumerable.Count();
        }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("rows")]
        public IEnumerable<T> Rows { get; set; }
    }
}