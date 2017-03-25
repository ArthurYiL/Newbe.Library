using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using Autofac.Core.Registration;
using FluentAssertions;
using Moq;
using Newbe.Test.TestHelpers;
using NewBe.Web.Easyui.Combobox;
using NewBe.Web.Easyui.Combobox.Exceptions;
using NewBe.Web.Easyui.Combobox.Resolvers;
using Xunit;

namespace NewBe.Web.Easyui.Tests.Combobox
{
    public class ComboboxResultFactoryTest
    {
        [Fact(DisplayName = "get ComoboxResult normaly")]
        public void Normal()
        {
            var list = new List<object> {new object()};
            var value = "Value";
            var text = "Text";
            TestHelper.Test()
                .Setup(mock =>
                {
                    mock.Mock<IComboboxTextResolver>().Setup(x => x.CanResolve(It.IsAny<object>())).Returns(true);
                    mock.Mock<IComboboxTextResolver>().Setup(x => x.ResolveText(It.IsAny<object>())).Returns(text);
                    mock.Mock<IComboboxTextResolver>().Setup(x => x.Order).Returns(1);
                    mock.Mock<IComboboxValueResolver>().Setup(x => x.CanResolve(It.IsAny<object>())).Returns(true);
                    mock.Mock<IComboboxValueResolver>().Setup(x => x.ResolveValue(It.IsAny<object>())).Returns(value);
                    mock.Mock<IComboboxValueResolver>().Setup(x => x.Order).Returns(1);
                })
                .GetServiceBuilder<ComboboxResultFactory, IComboboxResultFactory>()
                .Build()
                .DoAction(x => x.Build(list.AsEasyuiList()))
                .Assert(x =>
                {
                    x.Count().Should().Be(list.Count);
                    x.Single().Text.Should().Be(text);
                    x.Single().Value.Should().Be(value);
                });
        }

        [Fact(DisplayName = "No avaliable resolvers")]
        public void NoAvaliableResolver()
        {
            var list = new List<object> {new object()};
            TestHelper.Test()
                .Setup(mock =>
                {
                    mock.Mock<IComboboxTextResolver>().Setup(x => x.CanResolve(It.IsAny<object>())).Returns(false);
                    mock.Mock<IComboboxTextResolver>().Setup(x => x.Order).Returns(1);
                    mock.Mock<IComboboxValueResolver>().Setup(x => x.CanResolve(It.IsAny<object>())).Returns(false);
                    mock.Mock<IComboboxValueResolver>().Setup(x => x.Order).Returns(1);
                })
                .GetServiceBuilder<ComboboxResultFactory, IComboboxResultFactory>()
                .Build()
                .DoAction(x => x.Build(list.AsEasyuiList()))
                .Throw<AvaliableResolverNotFoundException>();
        }

        //TODO add Ordered Resolver Text
    }
}