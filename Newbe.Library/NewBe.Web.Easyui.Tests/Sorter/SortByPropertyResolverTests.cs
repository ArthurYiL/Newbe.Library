using FluentAssertions;
using FluentAssertions.Common;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Sorter;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Sorter
{
    public class SortByPropertyResolverTests
    {
        public class Item
        {
            public string Name { get; set; }

            [EasyuiDefaultSortBy]
            public int? Age { get; set; }
        }

        [Fact(DisplayName = "resolve property with property name")]
        public void Normal()
        {
            TestHelper.Test()
                .GetServiceBuilder<SortByPropertyResolver<Item>, ISotyByPropertyResolver<Item>>()
                .Build()
                .DoAction(x => x.ResolveSortByProperty(nameof(Item.Name)))
                .Assert(x => x.Should().BeSameAs(typeof(Item).GetPropertyByName(nameof(Item.Name))));
        }

        [Fact(DisplayName = "there is no 'sortby',use EasyuiDeafultSortBy as default sortby")]
        public void SortByDeafultWithAttribute()
        {
            TestHelper.Test()
                .GetServiceBuilder<SortByPropertyResolver<Item>, ISotyByPropertyResolver<Item>>()
                .Build()
                .DoAction(x => x.ResolveSortByProperty("NotFoundPropertyName"))
                .Assert(x => x.Should().BeSameAs(typeof(Item).GetPropertyByName(nameof(Item.Age))));
        }

        public class ItemWithId
        {
            public string Name { get; set; }
            public string ItemId { get; set; }
        }

        [Fact(DisplayName = "there is no 'sortby',use property which name contains 'Id' as default sortby")]
        public void SortByDeafultIdProperty()
        {
            TestHelper.Test()
                .GetServiceBuilder<SortByPropertyResolver<ItemWithId>, ISotyByPropertyResolver<ItemWithId>>()
                .Build()
                .DoAction(x => x.ResolveSortByProperty("NotFoundPropertyName"))
                .Assert(x => x.Should().BeSameAs(typeof(ItemWithId).GetPropertyByName(nameof(ItemWithId.ItemId))));
        }
    }
}