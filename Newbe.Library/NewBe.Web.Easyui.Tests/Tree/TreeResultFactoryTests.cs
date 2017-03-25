using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Tree;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Tree
{
    public class TreeResultFactoryTests
    {
        public class Item
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public int? Age { get; set; }
        }

        [Fact(DisplayName = "formate a list to tree")]
        public void Normal()
        {
            var item = new Item {Name = "name1", Age = 123, Code = "code1"};
            var list = new List<Item>
            {
                item,
            };
            TestHelper.Test()
                .Setup()
                .GetServiceBuilder<TreeResultFactory, ITreeResultFactory>()
                .Build()
                .DoAction(x => x.Build(list.AsEasyuiList(), new EasyuiTreeBuildOptions<Item>
                {
                    IdFunc = a => a.Code,
                    TextFunc = a => a.Name,
                    AttributesFunc = a => new {a.Age}
                }))
                .Assert(x =>
                {
                    x.Single().Text.Should().Be(item.Name);
                    x.Single().Id.Should().Be(item.Code);
                    ((int) ((dynamic) x.Single().Attributes).Age).Should().Be(123);
                });
        }

        public class ItemWithAttribue
        {
            [EasyuiTreeText]
            public string Name { get; set; }

            [EasyuiTreeId]
            public string Code { get; set; }

            public int? Age { get; set; }
        }

        [Fact(DisplayName = "formate a list to tree,list item with EasyuiTreeAttribute")]
        public void FormateItemWithAttribue()
        {
            var item = new ItemWithAttribue {Name = "name1", Age = 123, Code = "code1"};
            var list = new List<ItemWithAttribue>
            {
                item,
            };
            TestHelper.Test()
                .Setup()
                .GetServiceBuilder<TreeResultFactory, ITreeResultFactory>()
                .Build()
                .DoAction(x => x.Build(list.AsEasyuiList(), new EasyuiTreeBuildOptions<ItemWithAttribue>
                {
                    AttributesFunc = a => new {a.Age}
                }))
                .Assert(x =>
                {
                    x.Single().Text.Should().Be(item.Name);
                    x.Single().Id.Should().Be(item.Code);
                });
        }
    }
}