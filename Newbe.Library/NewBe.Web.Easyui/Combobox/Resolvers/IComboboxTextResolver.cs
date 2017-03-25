namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal interface IComboboxTextResolver
    {
        string ResolveText<T>(T item);

        bool CanResolve<T>(T item);

        int Order { get; }
    }
}