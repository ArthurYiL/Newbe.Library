#if NET452
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Newbe.Web.Mvc.Easyui
{
    public static class EasyuiValidationExtension
    {
        public static void MergeEasyuiValidation(HtmlHelper htmlHelper, ModelMetadata metadata, string name,
            TagBuilder tagBuilder1)
        {
            var vals = htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata);
            tagBuilder1.MergeAttributes(vals);
//            if (vals.ContainsKey("data-val"))
//            {
//                Dictionary<string, object> dataoptions;
//                if (tagBuilder1.Attributes.ContainsKey("data-options"))
//                {
//                    dataoptions =
//                        JsonConvert.DeserializeObject<Dictionary<string, object>>(
//                            $"{{{tagBuilder1.Attributes["data-options"]}}}");
//                }
//                else
//                {
//                    dataoptions = new Dictionary<string, object>();
//                }

//#region 生成验证函数

//                if (dataoptions.ContainsKey("validType"))
//                {
//                    var obj = dataoptions["validType"];
//                    if (obj is JArray)
//                    {
//                        dataoptions["validType"] =
//                            ((JArray) dataoptions["validType"]).Select(x => x.Value<string>()).ToList();
//                    }
//                }
//                var converters = new List<ConverterBase>()
//                {
//                    new IPAddressConverter(vals, dataoptions),
//                    new MacAddressConverter(vals, dataoptions),
//                    new MaxLengthConverter(vals, dataoptions),
//                    new MinLengthConverter(vals, dataoptions),
//                    new RequiredConverter(vals, dataoptions),
//                    new UrlConverter(vals, dataoptions),
//                };
//                foreach (var converter in converters)
//                {
//                    converter.Convert();
//                }
//                if (dataoptions.ContainsKey("validType"))
//                {
//                    var obj = dataoptions["validType"];
//                    if (!(obj is string))
//                    {
//                        dataoptions["validType"] = obj.ToJson();
//                    }
//                }

//#endregion

//                var optionsStrBuilder = new StringBuilder();
//                foreach (var item in dataoptions)
//                {
//                    if (item.Key == "validType") //validType
//                    {
//                        optionsStrBuilder.Append(
//                            $"{item.Key}:{item.Value.ToString().Replace("\"", "'")},");
//                    }
//                    else if (item.Value is bool) //bool需要转为小写
//                    {
//                        optionsStrBuilder.Append(
//                            $"{item.Key}:{item.Value.ToString().ToLower()},");
//                    }
//                    else if (item.Value is string) //字符串要加引号
//                    {
//                        optionsStrBuilder.Append(
//                            $"{item.Key}:'{item.Value}',");
//                    }
//                    else //其他的就随便吧
//                    {
//                        optionsStrBuilder.Append(
//                            $"{item.Key}:{item.Value},");
//                    }
//                }
//                var re = optionsStrBuilder.Length > 0
//                    ? optionsStrBuilder.ToString().TrimEnd(',')
//                    : optionsStrBuilder.ToString();
//                tagBuilder1.MergeAttribute("data-options", re, true);
//            }
        }

        /// <summary>
        /// 生成客户端验证方法
        /// </summary>
        /// <param name="funcName">window.easyuiValidation中的方法名称</param>
        /// <param name="inValidMsg">验证失败提示信息</param>
        /// <param name="ps">其他参数</param>
        /// <returns></returns>
        public static string GetClientValidateFunc(this HtmlHelper helper, string funcName, string inValidMsg,
            params string[] ps)
        {
            throw new NotImplementedException();
            //return EasyuiConverterBase.GetClientValidateFunc(funcName, inValidMsg, ps);
        }
    }
}

#endif