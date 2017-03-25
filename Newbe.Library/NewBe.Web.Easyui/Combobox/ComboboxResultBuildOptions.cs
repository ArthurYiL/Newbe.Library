using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBe.Web.Easyui.Combobox
{
    public class ComboboxResultBuildOptions<T>
    {
        public Func<T, string> TextFunc { get; set; }
        public Func<T, string> ValueFunc { get; set; }
    }
}