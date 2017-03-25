namespace NewBe.Web.Easyui
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}