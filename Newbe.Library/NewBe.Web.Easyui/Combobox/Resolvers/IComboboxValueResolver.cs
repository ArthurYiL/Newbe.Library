namespace NewBe.Web.Easyui.Combobox.Resolvers
{
    internal interface IComboboxValueResolver
    {
        string ResolveValue<T>(T item);

        bool CanResolve<T>(T item);

        int Order { get; }
    }
}