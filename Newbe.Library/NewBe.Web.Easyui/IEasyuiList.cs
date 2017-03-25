using System.Collections.Generic;

namespace NewBe.Web.Easyui
{
    /// <summary>
    /// Easyui列表结果，需要将列表转换为此接口才能使用Easyui特有的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEasyuiList<out T> : IEasyuiResponce
    {
        IEnumerable<T> AsEnumerable();
    }
}