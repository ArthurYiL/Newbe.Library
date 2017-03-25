#if NETSTANDARD1_4

using Microsoft.AspNetCore.Mvc.Routing;
using NewBe.Web.Easyui;

namespace Newbe.Web.Mvc.Easyui.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    public static class UrlHelperExtensions
    {
        internal class UrlhelperWapper : IUrlHelper
        {
            private readonly IUrlHelper _urlHelper;
            private readonly EasyuiAcceptType _acceptType;

            public UrlhelperWapper(IUrlHelper urlHelper, EasyuiAcceptType acceptType)
            {
                _urlHelper = urlHelper;
                _acceptType = acceptType;
            }

            public string Action(UrlActionContext actionContext)
            {
                return _urlHelper.Action(actionContext);
            }

            public string Content(string contentPath)
            {
                return _urlHelper.Content(contentPath);
            }

            public bool IsLocalUrl(string url)
            {
                return _urlHelper.IsLocalUrl(url);
            }

            public string RouteUrl(UrlRouteContext routeContext)
            {
                return _urlHelper.RouteUrl(routeContext);
            }

            public string Link(string routeName, object values)
            {
                return _urlHelper.Link(routeName, values);
            }

            public ActionContext ActionContext => _urlHelper.ActionContext;
        }

        public static IUrlHelper EasyuiAccept(this IUrlHelper urlhelper, EasyuiAcceptType acceptType)
        {
            var url = new UrlhelperWapper(urlhelper, acceptType);
            return url;
        }
    }
}

#endif
#if NET452
using System.Web.Mvc;
using System.Web.Routing;
using NewBe.Web.Easyui;

namespace Newbe.Web.Mvc.Easyui.Extensions
{

    public static class UrlHelperExtensions
    {
        internal class EasyuiUrlhelperWrapper : UrlHelper
        {
            private readonly UrlHelper _helper;
            private readonly EasyuiAcceptType _acceptType;
            public EasyuiUrlhelperWrapper(UrlHelper helper, EasyuiAcceptType acceptType)
            {
                _helper = helper;
                _acceptType = acceptType;
            }

            public override string Action()
            {
                return _helper.Action();
            }

            public override string Action(string actionName)
            {
                return _helper.Action(actionName,new {accept = _acceptType });
            }

            public override string Action(string actionName, object routeValues)
            {
                RouteValueDictionary routeData;
                if (routeValues != null)
                {
                    routeData = new RouteValueDictionary(routeValues);
                    if (!routeData.ContainsKey("accept"))
                    {
                        routeData.Add("accept", _acceptType.ToString());
                    }
                }
                else
                {
                    routeData = new RouteValueDictionary {
                        ["accept"] = _acceptType.ToString()
                    };
                }
                return _helper.Action(actionName, routeData);
            }

            public override string Action(string actionName, RouteValueDictionary routeValues)
            {
                return _helper.Action(actionName, routeValues);
            }

            public override string Action(string actionName, string controllerName)
            {
                return _helper.Action(actionName, controllerName);
            }

            public override string Action(string actionName, string controllerName, object routeValues)
            {
                return _helper.Action(actionName, controllerName, routeValues);
            }

            public override string Action(string actionName, string controllerName, RouteValueDictionary routeValues)
            {
                return _helper.Action(actionName, controllerName, routeValues);
            }

            public override string Action(string actionName, string controllerName, RouteValueDictionary routeValues,
                string protocol)
            {
                return _helper.Action(actionName, controllerName, routeValues, protocol);
            }

            public override string Action(string actionName, string controllerName, object routeValues, string protocol)
            {
                return _helper.Action(actionName, controllerName, routeValues, protocol);
            }

            public override string Action(string actionName, string controllerName, RouteValueDictionary routeValues,string protocol,
                string hostName)
            {
                return _helper.Action(actionName, controllerName, routeValues, protocol, hostName);
            }

            public override string Content(string contentPath)
            {
                return _helper.Content(contentPath);
            }

            public override string Encode(string url)
            {
                return _helper.Encode(url);
            }

            public override bool IsLocalUrl(string url)
            {
                return _helper.IsLocalUrl(url);
            }

            public override string RouteUrl(object routeValues)
            {
                return _helper.RouteUrl(routeValues);
            }

            public override string RouteUrl(RouteValueDictionary routeValues)
            {
                return _helper.RouteUrl(routeValues);
            }

            public override string RouteUrl(string routeName)
            {
                return _helper.RouteUrl(routeName);
            }

            public override string RouteUrl(string routeName, object routeValues)
            {
                return _helper.RouteUrl(routeName, routeValues);
            }

            public override string RouteUrl(string routeName, RouteValueDictionary routeValues)
            {
                return _helper.RouteUrl(routeName, routeValues);
            }

            public override string RouteUrl(string routeName, object routeValues, string protocol)
            {
                return _helper.RouteUrl(routeName, routeValues, protocol);
            }

            public override string RouteUrl(string routeName, RouteValueDictionary routeValues, string protocol,
                string hostName)
            {
                return _helper.RouteUrl(routeName, routeValues, protocol, hostName);
            }

            public override string HttpRouteUrl(string routeName, object routeValues)
            {
                return _helper.HttpRouteUrl(routeName, routeValues);
            }

            public override string HttpRouteUrl(string routeName, RouteValueDictionary routeValues)
            {
                return _helper.HttpRouteUrl(routeName, routeValues);
            }
        }

        public static UrlHelper EasyuiAccept(this UrlHelper urlhelper, EasyuiAcceptType acceptType)
        {
            var wrapper = new EasyuiUrlhelperWrapper(urlhelper, acceptType);
            return wrapper;
        }


    }
}
#endif