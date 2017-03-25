using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Sorter;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Sorter
{
    public class EnumerableEasyuiSorterTest
    {
        public class Item
        {
            public string Name { get; set; }
            public int? Age { get; set; }
        }

        [Theory(DisplayName = "sort enumerable items with easyui sort")]
        [InlineData(SortOrder.Desc)]
        [InlineData(SortOrder.Asc)]
        public void Normal(SortOrder order)
        {
            var item1 = new Item {Name = "1", Age = 1};
            var itemnull = new Item {Name = "null", Age = null};
            var item2 = new Item {Name = "2", Age = 2};
            var list = new List<Item>
            {
                item1,
                itemnull,
                item2,
            };
            TestHelper.Test()
                .Setup(mock =>
                {
                    var nameName = nameof(Item.Name);
                    mock.Mock<IEasyuiSorter>().Setup(x => x.SortBy).Returns(nameName);
                    mock.Mock<IEasyuiSorter>().Setup(x => x.Order).Returns(order);
                    mock.Mock<ISotyByPropertyResolver<Item>>()
                        .Setup(x => x.ResolveSortByProperty(nameName))
                        .Returns(typeof(Item).GetRuntimeProperty(nameName));
                })
                .GetServiceBuilder<EnumerableEasyuiSorter<Item>, IEnumerableSorter<Item>>()
                .Build()
                .DoAction(x => x.Sort(list))
                .Assert(x =>
                {
                    if (order == SortOrder.Asc)
                    {
                        x.Should().BeInAscendingOrder(a => a.Name);
                    }
                    else
                    {
                        x.Should().BeInDescendingOrder(a => a.Name);
                    }
                });
        }

        [Theory(DisplayName = "sort enumerable items with easyui sort nullableType")]
        [InlineData(SortOrder.Desc)]
        [InlineData(SortOrder.Asc)]
        public void NullableType(SortOrder order)
        {
            var item1 = new Item {Name = "1", Age = 1};
            var itemnull = new Item {Name = "null", Age = null};
            var item2 = new Item {Name = "2", Age = 2};
            var list = new List<Item>
            {
                item1,
                itemnull,
                item2,
            };
            TestHelper.Test()
                .Setup(mock =>
                {
                    var nameName = nameof(Item.Age);
                    mock.Mock<IEasyuiSorter>().Setup(x => x.SortBy).Returns(nameName);
                    mock.Mock<IEasyuiSorter>().Setup(x => x.Order).Returns(order);
                    mock.Mock<ISotyByPropertyResolver<Item>>()
                        .Setup(x => x.ResolveSortByProperty(nameName))
                        .Returns(typeof(Item).GetRuntimeProperty(nameName));
                })
                .GetServiceBuilder<EnumerableEasyuiSorter<Item>, IEnumerableSorter<Item>>()
                .Build()
                .DoAction(x => x.Sort(list))
                .Assert(x =>
                {
                    if (order == SortOrder.Asc)
                    {
                        x.Should().BeInAscendingOrder(a => a.Age);
                    }
                    else
                    {
                        x.Should().BeInDescendingOrder(a => a.Age);
                    }
                });
        }
    }
}