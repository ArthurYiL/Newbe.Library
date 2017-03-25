using FluentAssertions;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Combobox.Resolvers;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Combobox
{
    public class PropertyNameComboboxValueResolverTest
    {
        internal class ItemWithNameProperty
        {
            public string Id { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'id' property ")]
        public void NormalWithName()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxValueResolver, IComboboxValueResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithNameProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithTextProperty
        {
            public string Value { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'value' property ")]
        public void NormalWithText()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxValueResolver, IComboboxValueResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithTextProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithStudentNameProperty
        {
            public string StudentId { get; set; }
        }

        [Fact(DisplayName = "can resolve with 'StudentId' property ")]
        public void SubMatch()
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxValueResolver, IComboboxValueResolver>()
                .Build()
                .DoAction(x => x.CanResolve(new ItemWithStudentNameProperty()))
                .Assert(x => x.Should().BeTrue());
        }

        internal class ItemWithNullType
        {
            public int? StudentId { get; set; }
        }

        [Theory(DisplayName = "get item with null type")]
        [InlineData(null)]
        [InlineData(1)]
        public void GetItemWithNullTypeNullValue(int? intValue)
        {
            TestHelper.Test()
                .GetServiceBuilder<PropertyNameComboboxValueResolver, IComboboxValueResolver>()
                .Build()
                .DoAction(x =>
                {
                    var item = new ItemWithNullType {StudentId = intValue};
                    x.CanResolve(item);
                    var resolveText = x.ResolveValue(item);
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