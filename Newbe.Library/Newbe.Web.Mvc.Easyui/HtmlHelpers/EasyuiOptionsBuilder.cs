
#if NET452
using System.Collections.Generic;
using System.Text;

namespace Newbe.Web.Mvc.Easyui.HtmlHelpers
{
    public class EasyuiOptionsBuilder : Dictionary<string, object>
    {
        public EasyuiOptionsBuilder(IDictionary<string, object> dictionary)
        {
            foreach (var item in dictionary)
            {
                Add(item.Key, item.Value);
            }
        }

        public override string ToString()
        {
            var optionsStrBuilder = new StringBuilder();
            foreach (var item in this)
            {
                if (item.Key == "validType") //validType
                {
                    optionsStrBuilder.Append(
                        $"{item.Key}:{item.Value.ToString().Replace("\"", "'")},");
                }
                else if (item.Value is bool) //bool需要转为小写
                {
                    optionsStrBuilder.Append(
                        $"{item.Key}:{item.Value.ToString().ToLower()},");
                }
                else if (item.Value is string) //字符串要加引号
                {
                    optionsStrBuilder.Append(
                        $"{item.Key}:'{item.Value}',");
                }
                else //其他的就随便吧
                {
                    optionsStrBuilder.Append(
                        $"{item.Key}:{item.Value},");
                }
            }
            var re = optionsStrBuilder.Length > 0
                ? optionsStrBuilder.ToString().TrimEnd(',')
                : optionsStrBuilder.ToString();
            return re;
        }
    }
}

#endif