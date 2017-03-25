namespace NewBe.Web.Easyui.Tree
{
    public interface ITreeResultFactory
    {
        TreeResult<T> Build<T>(IEasyuiList<T> items, EasyuiTreeBuildOptions<T> buildOptions);
    }
}