using FluentAssertions;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Combobox.Resolvers;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Combobox
{
    public class PropertyNameComboboxTextResolverTest
    {
        internal class ItemWithNameProperty
        {
            public string Name { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'name' property ")]
        public void NormalWithName()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithNameProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithTextProperty
        {
            public string Text { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'text' property ")]
        public void NormalWithText()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithTextProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithStudentNameProperty
        {
            public string StudentName { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'StudentName' property ")]
        public void SubMatch()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithStudentNameProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithNullType
        {
            public int? StudentName { get; set; }
        }

        [Theory(DisplayName = "get item with null type")]
        [InlineData(null)]
        [InlineData(1)]
        public void GetItemWithNullTypeNullValue(int? intValue)
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxTextResolver, IComboboxTextResolver>()
                .Build()
                .DoAction(x =>
                {
                    var item = new ItemWithNullType {StudentName = intValue};
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