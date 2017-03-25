
namespace NewBe.Web.Easyui.Combobox
{
    public interface IComboboxResultFactory
    {
        ComboboxResult Build<T>(IEasyuiList<T> items);
    }
}