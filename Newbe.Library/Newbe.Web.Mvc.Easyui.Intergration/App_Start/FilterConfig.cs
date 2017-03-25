using System.Web;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui.Intergration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
