using FluentAssertions;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Combobox;
using NewBe.Web.Easyui.Combobox.Resolvers;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Combobox
{
    public class ComboboxAttributeComboboxTextResolverTest
    {
        internal class ItemWithAttribute
        {
            [EasyuiComboboxText]
            public string Foo { get; set; }
        }


        [Fact(DisplayName = "can resolve with attribute")]
        public void Normal()
        {
            TestHelper.Test()
                .GetServiceBuilder<ComboboxAttributeComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithAttribute()))
                .Assert(x => x.Should().BeTrue());
        }

        [Theory(DisplayName = "resolve string property")]
        [InlineData(null)]
        [InlineData("foo")]
        public void GetValue(string foo)
        {
            TestHelper.Test()
                .GetServiceBuilder<ComboboxAttributeComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x =>
                {
                    var item = new ItemWithAttribute
                    {
                        Foo = foo
                    };
                    x.CanResolve(item);
                    return x.ResolveText(item);
                })
                .Assert(x => x.Should().Be(foo));
        }

        internal class ItemCantResolve
        {
            public string Foo { get; set; }
        }

        [Fact(DisplayName = "can not resolve type without attribute")]
        public void CantResolve()
        {
            TestHelper.Test()
                .GetServiceBuilder<ComboboxAttributeComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemCantResolve()))
                .Assert(x => x.Should().BeFalse());
        }


        internal class ItemWithNullType
        {
            [EasyuiComboboxText]
            public int? NullInt { get; set; }
        }

        [Theory(DisplayName = "get item with null type")]
        [InlineData(null)]
        [InlineData(1)]
        public void GetItemWithNullTypeNullValue(int? intValue)
        {
            TestHelper.Test()
                .GetServiceBuilder<ComboboxAttributeComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x =>
                {
                    var item = new ItemWithNullType {NullInt = intValue};
                    x.CanResolve(item);
                    var resolveText = x.ResolveText(item);
                    return resolveText;
                })
                .Assert(x =>
                {
                    if (intValue.HasValue)
                    {
                        x.Should().Be(intValue.Value.ToString());
                    }
                    else
                    {
                        x.Should().BeNullOrEmpty();
                    }
                });
        }
    }
}