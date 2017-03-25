using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBe.Web.Easyui.Tree
{
    public class EasyuiTreeBuildOptions<T>
    {
        public Func<T, string> IdFunc { get; set; }
        public Func<T, string> TextFunc { get; set; }
        public Func<T, object> AttributesFunc { get; set; }
    }
}