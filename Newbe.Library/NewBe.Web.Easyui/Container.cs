using System;
using System.Collections.Generic;
using System.Linq;
using NewBe.Web.Easyui.Combobox;
using NewBe.Web.Easyui.Combobox.Resolvers;
using NewBe.Web.Easyui.Tree;

namespace NewBe.Web.Easyui
{
    public class Container : IContainer
    {
        private class ContainerRegistation
        {
            protected ContainerRegistation(Type type, Func<object> resolver)
            {
                Type = type;
                Resolver = resolver;
            }

            public Type Type { get; set; }

            public Func<object> Resolver { get; set; }
        }

        private class ContainerRegistation<T> : ContainerRegistation
        {
            public ContainerRegistation(Func<T> func) : base(typeof(T), () => func())
            {
            }
        }

        private static readonly IEnumerable<ContainerRegistation> ResolveContainerDictionary;

        static Container()
        {
            ResolveContainerDictionary = new ContainerRegistation[]
            {
                new ContainerRegistation<IComboboxResultFactory>(() =>
                    new ComboboxResultFactory(
                        Global.Resolve<IEnumerable<IComboboxTextResolver>>(),
                        Global.Resolve<IEnumerable<IComboboxValueResolver>>())),
                new ContainerRegistation<IEnumerable<IComboboxTextResolver>>(() =>
                    new IComboboxTextResolver[]
                    {
                        new ComboboxAttributeComboboxTextResolver(),
                        new PropertyNameComboboxTextResolver(),
                    }),
                new ContainerRegistation<IEnumerable<IComboboxValueResolver>>(() =>
                    new IComboboxValueResolver[]
                    {
                        new ComboboxAttributeComboboxValueResolver(),
                        new PropertyNameComboboxValueResolver(),
                    }),
                new ContainerRegistation<ITreeResultFactory>(() =>
                    new TreeResultFactory()),
            };
            Global = new Container();
        }

        internal Container()
        {
        }

        public static IContainer Global { get; set; }

        T IContainer.Resolve<T>()
        {
            return (T) ResolveContainerDictionary.First(x => x.Type == typeof(T)).Resolver();
        }
    }
}